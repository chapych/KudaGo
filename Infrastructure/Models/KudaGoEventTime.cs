using System.Text.Json.Serialization;

namespace Infrastructure.Models;

public class KudaGoEventTime
{
    [JsonPropertyName("start")]
    public long? Start { get; set; }

    [JsonPropertyName("end")]
    public long? End { get; set; }

    public (DateTime, DateTime) ToDateTime()
    {
        var start = DateTimeOffset.FromUnixTimeSeconds((long)Start!).LocalDateTime;
        var end = DateTimeOffset.FromUnixTimeSeconds((long)End!).LocalDateTime;

        return (start, end);
    }
}