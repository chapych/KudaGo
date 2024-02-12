using Entities.Enums;

namespace UseCases;

public class KudaGoRequest
{
    public int Count { get; set; }
    public Category[] Categories { get; set; } = null!;
    public DateTime Date { get; set; }
}