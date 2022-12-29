namespace PokemonWEB.Models;

/// <summary>
/// Pokedex is library with Pokemons, which will be associated using the PokemonID with the Pokemons class for pokemons property
/// </summary>
public class Pokedex
{
    public int PokedexId { get; set; }
    public string Name { get; set; }
    public int PokemonPower { get; set; }
    public int BaseDamage { get; set; }
    public int BaseHP { get; set; }
    public int BaseDefense { get; set; }
    public double Weight { get; set; }
    public double Height { get; set; }

    public string ImageURL { get; set; }
    
    public ICollection<Pokemon> Pokemons { get; set; }
}