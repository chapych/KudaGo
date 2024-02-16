using System.Text.Json.Serialization;

namespace KudaGo.Infrastructure.Models;

internal class KudaGoPlace
{
    [JsonPropertyName("title")]
    public string? Name { get; set; }
    [JsonPropertyName("address")]
    public string? Address { get; set; }
    [JsonPropertyName("subway")]
    public string? Subway { get; set; }

    [JsonPropertyName("coords")]
    public Coords? Coords { get; set; }
}