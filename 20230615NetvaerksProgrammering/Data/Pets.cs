using System.Drawing;

namespace _20230615NetvaerksProgrammering.Data;

public class Pets
{
    public Pets()
    {
    }

    public Pets(int id, string? name, string? species, string? breed, string? colour, int speed, double price)
    {
        Id = id;
        Name = name;
        Species = species;
        Breed = breed;
        Colour = colour;
        Speed = speed;
        Price = price;
    }

    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Species { get; set; }
    public string? Breed   { get; set; }
    public string? Colour { get; set; }
    public int Speed { get; set; }
    public double Price { get; set; }
}
