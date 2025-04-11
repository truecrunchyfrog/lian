namespace Backend.Models.Entities
{
  public class InternshipTerm : IntoDto<Dto.InternshipTerm>
  {
    public int Id { get; set; }
    public required Organization Organization { get; set; }
    public required Period ApplicationPeriod { get; set; }
    public required Period PracticePeriod { get; set; }
    public ICollection<Contact> Contacts { get; set; } = [];
    public ICollection<Tag> Tags { get; set; } = [];

    public bool IsRelevant =>
      DateOnly.FromDateTime(DateTime.Today) < ApplicationPeriod.End;

    public Dto.InternshipTerm ToDto() => new Dto.InternshipTerm
      {
        Id = Id,
        Organization = Organization.ToDto(),
        ApplicationPeriod = ApplicationPeriod.ToDto(),
        PracticePeriod = PracticePeriod.ToDto(),
        Contacts = Contacts.Select(c => c.ToDto()),
        Tags = Tags.Select(t => t.ToDto())
      };
  }
}

namespace Backend.Models.Dto
{
  public class InternshipTerm
  {
    public int Id { get; set; }
    public required Organization Organization { get; set; }
    public required Period ApplicationPeriod { get; set; }
    public required Period PracticePeriod { get; set; }
    public IEnumerable<Contact> Contacts { get; set; } = [];
    public IEnumerable<Tag> Tags { get; set; } = [];
  }
}
