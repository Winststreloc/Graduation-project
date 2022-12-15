namespace PokemonWEB.Models;

public class Pokedex
{
    public int PokedexId { get; set; }
    public string Name { get; set; }
    public int Weight { get; set; }
    public int Height { get; set; }
    public int BaseDamage { get; set; }
    public int BaseHP { get; set; }
    public int BaseDefense { get; set; }
    
    public string ImageURL { get; set; }
    
}