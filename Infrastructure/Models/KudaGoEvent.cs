using System.Text.Json.Serialization;

namespace KudaGo.Infrastructure.Models;

internal class KudaGoEvent
{
    [JsonPropertyName("id")]
    public int Id { get; init; }

    [JsonPropertyName("title")]
    public string Name { get; init; } = null!;
    [JsonPropertyName("dates")]
    public IEnumerable<KudaGoEventTime>? Dates { get; init; }
    [JsonPropertyName("description")]
    public string? Description { get; init; }
    [JsonPropertyName("place")]
    public KudaGoPlace? Place { get; init; }

}