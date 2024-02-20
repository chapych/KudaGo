namespace KudGo.Entities.Entities;

public class Place
{
    public string Name { get; init; } = null!;
    public string? Address { get; init; } = null!;
    public string? Subway { get; init; } = null!;
    public Coords? Coords { get; init; } = null!;
}