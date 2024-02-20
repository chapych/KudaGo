using System.Text.Json.Serialization;

namespace KudaGo.Infrastructure.Models;

internal class KudaGoEventTime
{
    [JsonPropertyName("start")]
    public long? StartUnix { get; init; }

    [JsonPropertyName("end")]
    public long? EndUnix { get; init; }

    [JsonIgnore]
    public DateTime Start { get; init; }

    [JsonIgnore]
    public DateTime End { get; init; }

    public KudaGoEventTime()
    {
        Start = DateTimeOffset.FromUnixTimeSeconds(StartUnix ?? 0).LocalDateTime;
        End = DateTimeOffset.FromUnixTimeSeconds(EndUnix ?? 0).LocalDateTime;
    }
}