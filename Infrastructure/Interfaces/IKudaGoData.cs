namespace KudaGo.Infrastructure.Interfaces;

public interface IKudaGoData<T>
{
    int Count { get; init; }
    string Next { get; init; }
    string Previous { get; init; }
    IEnumerable<T> Events { get; init; }
}