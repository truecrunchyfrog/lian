namespace Backend.Models.Entities
{
  public class Period : IntoDto<Dto.Period>
  {
    public int Id { get; set; }
    public required DateOnly Start { get; set; }
    public required DateOnly End { get; set; }

    public Dto.Period ToDto() => new Dto.Period
      {
        Start = Start,
        End = End
      };
  }
}

namespace Backend.Models.Dto
{
  public class Period
  {
    public required DateOnly Start { get; set; }
    public required DateOnly End { get; set; }
  }
}
