using System.Text.Json.Serialization;

namespace Infrastructure.Models;

public class Coords
{
    [JsonPropertyName("lat")]
    public double Latitude { get; set; }
    [JsonPropertyName("lon")]
    public double Longitude { get; set; }
}