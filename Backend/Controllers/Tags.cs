using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers;

[Route("[controller]")]
[ApiController]
public class Tags : ControllerBase
{
  [HttpGet]
  public ActionResult<IEnumerable<Models.Dto.Tag>> All(BackendContext context) =>
    context.Tags
      .Select(o => o.ToDto())
      .ToList();
}
