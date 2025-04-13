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
      .Include(t => t.InternshipPositions)
      .ThenInclude(it => it.ApplicationPeriod)
      .OrderByDescending(t => t.InternshipPositions.Count)
      .ToList()
      .Where(t => t.InternshipPositions.Count(it => it.IsRelevant) > 0)
      .Select(t => t.ToDto()));
}
