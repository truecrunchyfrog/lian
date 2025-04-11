using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend.Controllers;

[Route("[controller]")]
[ApiController]
public class InternshipTerms : ControllerBase
{
  [HttpGet]
  public ActionResult<IEnumerable<Models.Dto.InternshipTerm>> Find(BackendContext context, [FromQuery] IEnumerable<int> tagIds) =>
    Ok(context.InternshipTerms
      .Include(it => it.Organization)
      .Include(it => it.ApplicationPeriod)
      .Include(it => it.PracticePeriod)
      .Include(it => it.Contacts)
      .Include(it => it.Tags)
      .Where(it => tagIds.Count() == 0 || it.Tags.Select(t => t.Id).Intersect(tagIds).Any())
      .Select(t => t.ToDto()));

  [HttpGet("count")]
  public ActionResult<int> Count(BackendContext context, [FromQuery] IEnumerable<int> tagIds) =>
    Ok(context.InternshipTerms
      .Include(it => it.Tags)
      .Where(it => tagIds.Count() == 0 || it.Tags.Select(t => t.Id).Intersect(tagIds).Any())
      .Count());
}
