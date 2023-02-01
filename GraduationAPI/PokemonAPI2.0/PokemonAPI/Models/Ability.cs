using PokemonAPI;

namespace PokemonWEB.Models.Action;

public class Ability
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Damage { get; set; }
    public int Healing { get; set; }
    public string? Description { get; set; }
    public string ImageUrl { get; set; }
    public ICollection<PokemonAbility> PokemonAbilities { get; set; }
}