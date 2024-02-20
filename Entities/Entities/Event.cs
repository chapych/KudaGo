namespace KudGo.Entities.Entities;

public class Event
{
    public int Id { get; init; }
    public string Name { get; init; }
    public IEnumerable<TimePeriod>? Dates { get; init; }
    public string? Description { get; init; }
    public Place? Place { get; init; }

    public Event(string name, string? description, IEnumerable<(DateTime start, DateTime end)>? dates)
    {
        Name = name;

        Dates = dates?.Select(x => new TimePeriod
        {
            Start = x.start,
            End = x.end
        });

        Description = description;
    }
}