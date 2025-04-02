using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers;

[Route("[controller]")]
[ApiController]
public class Organizations : ControllerBase
{
  [HttpGet]
  public ActionResult<IEnumerable<Models.Dto.Organization>> Find(BackendContext context, DateOnly? rangeFrom, DateOnly? rangeTo) =>
    context.Organizations
      //.Where(o => o.Expiration < DateOnly.FromDateTime(DateTime.Now))
      //.Where(o => rangeFrom == null || rangeTo == null || o.InternshipPeriods.Any(p => p.PracticePeriod.Start < rangeFrom && p.PracticePeriod.End > rangeTo))
      .Select(o => o.ToDto())
      .ToList();
}
