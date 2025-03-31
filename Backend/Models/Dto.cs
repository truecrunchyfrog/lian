namespace Backend.Models.Entities;

public interface IntoDto<T>
{
  public T ToDto();
}
