namespace PokemonWEB.Models;

public class Pokedex
{
    public int Id { get; set; }
    public int PokedexId { get; set; }
    public string Name { get; set; }
    public int Weight { get; set; }
    public int Height { get; set; }
    public double BaseDamage { get; set; }
    public double BaseHP { get; set; }
    public double Defense { get; set; }
}