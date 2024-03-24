using KudGo.Entities.Entities;
using KudGo.Entities.Enums;

namespace KudaGo.Entities.Entities;

public class KudaGoEvent
{
    public int Id { get; init; }
    public string Name { get; init; }
    public IEnumerable<TimePeriod>? Dates { get; init; }
    public string? Description { get; init; }
    public Place? Place { get; init; }
    public IEnumerable<Category>? Categories { get; init; }

    public KudaGoEvent(string name, string? description, IEnumerable<(DateTime start, DateTime end)>? dates, IEnumerable<Category>? categories)
    {
        Name = name;

        Dates = dates?.Select(x => new TimePeriod
        {
            Start = x.start,
            End = x.end
        });

        Description = description;
        Categories = categories;
    }
}