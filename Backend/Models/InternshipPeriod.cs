namespace Backend.Models.Entities
{
  public class InternshipPeriod : IntoDto<Dto.InternshipPeriod>
  {
    public int Id { get; set; }
    public required ICollection<Contact> Contacts { get; set; }
    public required Period ApplicationPeriod { get; set; }
    public required Period PracticePeriod { get; set; }

    public Dto.InternshipPeriod ToDto() => new Dto.InternshipPeriod
      {
        Id = Id,
        Contacts = Contacts.Select(c => c.ToDto()),
        ApplicationPeriod = ApplicationPeriod.ToDto(),
        PracticePeriod = PracticePeriod.ToDto()
      };
  }
}

namespace Backend.Models.Dto
{
  public class InternshipPeriod
  {
    public int Id { get; set; }
    public required IEnumerable<Contact> Contacts { get; set; }
    public required Period ApplicationPeriod { get; set; }
    public required Period PracticePeriod { get; set; }
  }
}
