namespace Backend.Models.Entities
{
  public class Tag : IntoDto<Dto.Tag>
  {
    public int Id { get; set; }
    public required string Name { get; set; }
    public ICollection<InternshipTerm> InternshipTerms { get; set; } = [];

    public Dto.Tag ToDto() => new Dto.Tag
      {
        Id = Id,
        Name = Name,
        TermsWithTag = InternshipTerms.Where(t => t.IsRelevant).Count()
      };
  }
}

namespace Backend.Models.Dto
{
  public class Tag
  {
    public int Id { get; set; }
    public required string Name { get; set; }
    public int TermsWithTag { get; set; }
  }
}
