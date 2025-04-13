using Backend.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend.Controllers;

[Route("[controller]")]
[ApiController]
public class InternshipPositions : ControllerBase
{
  [HttpGet]
  public ActionResult<IEnumerable<Models.Dto.InternshipPosition>> Find(
      BackendContext context,
      [FromQuery] IEnumerable<int> tagIds,
      [FromQuery] IEnumerable<int> orgIds) =>
    Ok(context.InternshipPositions
      .Include(it => it.Organization)
      .Include(it => it.ApplicationPeriod)
      .Include(it => it.PracticePeriod)
      .Include(it => it.Contacts)
      .Include(it => it.Tags)
      .FilterInternshipPositions(tagIds, orgIds)
      .Select(t => t.ToDto()));

  [HttpGet("count")]
  public ActionResult<int> Count(
      BackendContext context,
      [FromQuery] IEnumerable<int> tagIds,
      [FromQuery] IEnumerable<int> orgIds) =>
    Ok(context.InternshipPositions
      .FilterInternshipPositions(tagIds, orgIds)
      .Count());
}
