using PokemonAPI;
using PokemonWEB.Models.Action;

namespace PokemonWEB.Models;

public class Pokemon
{
    public Guid Id { get; set; }
    public int PokedexId { get; set; }
    public string Name { get; set; }
    public int Weight { get; set; }
    public int Height { get; set; }
    public bool Gender { get; set; }
    public int Experiance { get; set; }
    
    public ICollection<PokemonAbility> PokemonAbilities { get; set; }
    public  ICollection<PokemonOwner> PokemonOwners { get; set; }
    public  ICollection<PokemonCategory> PokemonCategories { get; set; }
}