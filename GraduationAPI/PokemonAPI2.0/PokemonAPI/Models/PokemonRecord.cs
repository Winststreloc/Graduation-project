using PokemonAPI.Models;

namespace PokemonWEB.Models;

/// <summary>
/// Pokedex is library with Pokemons, which will be associated using the PokemonID with the Pokemons class for pokemons property
/// </summary>
public class PokemonRecord
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int PokemonPower { get; set; }
    public int BaseDamage { get; set; }
    public int BaseHP { get; set; }
    public int BaseDefense { get; set; }
    public double Weight { get; set; }
    public double Height { get; set; }
    public string? Description { get; set; }
    public string MainUrl { get; set; }
    
    public ICollection<PokemonRecordCategory> PokemonRecordCategories { get; set; }
    public ICollection<string> CategoryUrl { get; set; }
    public int? NextEvol { get; set; }
    public int? PrevEvol { get; set; }
    public string? PokEvol1 { get; set; }
    public string? PokEvol2 { get; set; }
    public string? PokEvol3 { get; set; }
}