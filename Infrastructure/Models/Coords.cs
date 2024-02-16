using System.Text.Json.Serialization;

namespace KudaGo.Infrastructure.Models;

internal class Coords
{
    [JsonPropertyName("lat")]
    public double Latitude { get; set; }
    [JsonPropertyName("lon")]
    public double Longitude { get; set; }
}