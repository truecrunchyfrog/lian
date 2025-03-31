namespace Backend.Models
{
  public enum ContactMethod
  {
    Email,
    Phone,
    Website
  }
}

namespace Backend.Models.Entities
{
  public class Contact : IntoDto<Dto.Contact>
  {
    public int Id { get; set; }
    public required ContactMethod Method { get; set; }
    public required string Value { get; set; }
    public required string? Description { get; set; }

    public Dto.Contact ToDto() => new Dto.Contact
      {
        Id = Id,
        Method = Method,
        Value = Value,
        Description = Description
      };
  }
}

namespace Backend.Models.Dto
{
  public class Contact
  {
    public int Id { get; set; }
    public required ContactMethod Method { get; set; }
    public required string Value { get; set; }
    public required string? Description { get; set; }
  }
}
