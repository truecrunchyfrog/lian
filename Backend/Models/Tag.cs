namespace Backend.Models.Entities
{
  public class Tag : IntoDto<Dto.Tag>
  {
    public int Id { get; set; }
    public required string Name { get; set; }
    public ICollection<InternshipPosition> InternshipPositions { get; set; } = [];

    public Dto.Tag ToDto() => new Dto.Tag
      {
        Id = Id,
        Name = Name,
        PositionsWithTag = InternshipPositions.Where(it => it.IsRelevant).Count()
      };
  }
}

namespace Backend.Models.Dto
{
  public class Tag
  {
    public int Id { get; set; }
    public required string Name { get; set; }
    public int PositionsWithTag { get; set; }
  }
}
