using KudGo.Entities.Entities;

namespace KudaGo.Infrastructure.Models;

public class Response
{
    public IEnumerable<Event> Events { get; init; } = null!;
}