using PokemonAPI;

namespace PokemonWEB.Models;

public class Pokemon
{
    public Guid Id { get; set; }
    public int PokedexId { get; set; }
    public string Name { get; set; }
    public int Weight { get; set; }
    public int Height { get; set; }
    public bool Gender { get; set; }
    public int Experience { get; set; }
    public  double BaseDamage { get; set; }
    public double BaseHP { get; set; }
    public double Defense { get; set; }
    
    
    public ICollection<PokemonAbility> PokemonAbilities { get; set; }
    public  ICollection<PokemonOwner> PokemonOwners { get; set; }
    public  ICollection<PokemonCategory> PokemonCategories { get; set; }
}