using Microsoft.EntityFrameworkCore;

namespace Backend.Models.Entities
{
  public class InternshipPosition : IntoDto<Dto.InternshipPosition>
  {
    public int Id { get; set; }
    public required Organization Organization { get; set; }
    public required Period ApplicationPeriod { get; set; }
    public required Period PracticePeriod { get; set; }
    public ICollection<Contact> Contacts { get; set; } = [];
    public ICollection<Tag> Tags { get; set; } = [];

    public bool IsRelevant =>
      DateOnly.FromDateTime(DateTime.Today) < ApplicationPeriod.End;

    public Dto.InternshipPosition ToDto() => new Dto.InternshipPosition
      {
        Id = Id,
        Organization = Organization.ToDto(),
        ApplicationPeriod = ApplicationPeriod.ToDto(),
        PracticePeriod = PracticePeriod.ToDto(),
        Contacts = Contacts.Select(c => c.ToDto()),
        Tags = Tags.Select(t => t.ToDto())
      };
  }

  public static class InternshipPositionExtensions
  {
    public static IQueryable<InternshipPosition> FilterInternshipPositions(
        this IQueryable<InternshipPosition> all,
        IEnumerable<int> tagIds,
        IEnumerable<int> orgIds) =>
      all
      .Include(it => it.Organization)
      .Include(it => it.Tags)
      .Where(it =>
          (tagIds.Count() == 0 && orgIds.Count() == 0) ||
          it.Tags.Select(t => t.Id).Intersect(tagIds).Any() ||
          orgIds.Contains(it.Organization.Id));
  }
}

namespace Backend.Models.Dto
{
  public class InternshipPosition
  {
    public int Id { get; set; }
    public required Organization Organization { get; set; }
    public required Period ApplicationPeriod { get; set; }
    public required Period PracticePeriod { get; set; }
    public IEnumerable<Contact> Contacts { get; set; } = [];
    public IEnumerable<Tag> Tags { get; set; } = [];
  }
}
