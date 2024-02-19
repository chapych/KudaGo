namespace KudGo.Entities.Entitites;

public class Event
{
    public string Name { get; set; }
    private readonly List<TimePeriod>? _dates;
    public IEnumerable<TimePeriod>? Dates => _dates?.AsReadOnly();
    public string? Description { get; set; }

    public Event(string name, string? description, IEnumerable<(DateTime start, DateTime end)>? dates)
    {
        Name = name;

        _dates = dates?.Select(x => new TimePeriod
            {
                Start = x.start,
                End = x.end
            })
            .ToList();

        Description = description;
    }
}