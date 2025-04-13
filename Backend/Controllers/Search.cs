using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend.Controllers;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum OptionType
{
  [JsonStringEnumMemberName("org")]
  Organization,
  [JsonStringEnumMemberName("tag")]
  Tag
}

public class SearchOption
{
  public int PropertyId { get; set; }
  public OptionType Type { get; set; }
  public required string Label { get; set; }
  public int AvailablePositions { get; set; }
  public required string? ImageHref { get; set; }
}

[Route("[controller]")]
[ApiController]
public class Search : ControllerBase
{
  [HttpGet]
  public ActionResult<IEnumerable<SearchOption>> FindOptions(BackendContext context) =>
    Ok(context.Organizations
      .Include(o => o.InternshipPositions)
      .Select(o => new SearchOption
        {
        Type = OptionType.Organization,
        PropertyId = o.Id,
        Label = o.Name,
        AvailablePositions = o.InternshipPositions.Count(),
        ImageHref = null // TODO
        })
      .Concat(
        context.Tags
        .Include(t => t.InternshipPositions)
        .Select(t => new SearchOption
          {
          Type = OptionType.Tag,
          PropertyId = t.Id,
          Label = t.Name,
          AvailablePositions = t.InternshipPositions.Count(),
          ImageHref = null
          })
        )
      );
}
