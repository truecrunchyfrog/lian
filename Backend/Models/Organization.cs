namespace Backend.Models.Entities
{
  public class Organization : IntoDto<Dto.Organization>
  {
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string AdministratorEmail { get; set; }
    public ICollection<InternshipTerm> InternshipTerms { get; set; } = [];
    public required DateOnly Expiration { get; set; }

    public Dto.Organization ToDto() => new Dto.Organization
      {
        Id = Id,
        Name = Name
      };
  }
}

namespace Backend.Models.Dto
{
  public class Organization
  {
    public int Id { get; set; }
    public required string Name { get; set; }
  }
}
