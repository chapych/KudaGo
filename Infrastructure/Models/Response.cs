using KudaGo.Entities.Entities;
using KudGo.Entities.Entities;

namespace KudaGo.Infrastructure.Models;

public class Response
{
    public IEnumerable<Entities.Entities.KudaGoEvent> Events { get; init; } = null!;
}