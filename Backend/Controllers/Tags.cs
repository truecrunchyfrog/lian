using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend.Controllers;

[Route("[controller]")]
[ApiController]
public class Tags : ControllerBase
{
  [HttpGet]
  public ActionResult<IEnumerable<Models.Dto.Tag>> All(BackendContext context) =>
    Ok(context.Tags
      .Include(t => t.InternshipTerms)
      .ThenInclude(it => it.ApplicationPeriod)
      .OrderByDescending(t => t.InternshipTerms.Count)
      .ToList()
      .Where(t => t.InternshipTerms.Count(it => it.IsRelevant) > 0)
      .Select(t => t.ToDto()));
}
