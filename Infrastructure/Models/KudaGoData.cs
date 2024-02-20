using System.Text.Json.Serialization;
using KudaGo.Infrastructure.Interfaces;

namespace KudaGo.Infrastructure.Models;

internal class KudaGoData<T> : IKudaGoData<T>
{
    [JsonPropertyName("count")]
    public int Count { get; init; }
    [JsonPropertyName("next")]
    public string? Next { get; init; }
    [JsonPropertyName("previous")]
    public string? Previous { get; init; }
    [JsonPropertyName("results")]
    public IEnumerable<T> Events { get; init; } = null!;
}