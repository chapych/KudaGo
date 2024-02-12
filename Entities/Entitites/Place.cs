namespace Entities.Entitites;

public class Place
{
    public string Name { get; set; } = null!;
    public string Address { get; set; } = null!;
    public string Subway { get; set; } = null!;
    public Coords Coords { get; set; } = null!;
}