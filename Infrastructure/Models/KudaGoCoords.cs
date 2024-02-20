using System.Text.Json.Serialization;

namespace KudaGo.Infrastructure.Models;

internal class KudaGoCoords
{
    [JsonPropertyName("lat")]
    public double Latitude { get; init; }
    [JsonPropertyName("lon")]
    public double Longitude { get; init; }
}