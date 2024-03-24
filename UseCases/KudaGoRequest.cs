using KudGo.Entities.Enums;

namespace KudaGo.UseCases;

public class KudaGoRequest
{
    public int Count { get; set; } = 10;
    public Category[] Categories { get; set; } = null!;
    public DateTime Date { get; set; } = DateTime.Now;
}