using System.Text.Json.Serialization;

namespace KudaGo.Infrastructure.Models;

internal class KudaGoPlace
{
    [JsonPropertyName("title")]
    public string Name { get; init; } = null!;

    [JsonPropertyName("address")]
    public string? Address { get; init; }
    [JsonPropertyName("subway")]
    public string? Subway { get; init; }

    [JsonPropertyName("coords")]
    public KudaGoCoords? Coords { get; init; }
}