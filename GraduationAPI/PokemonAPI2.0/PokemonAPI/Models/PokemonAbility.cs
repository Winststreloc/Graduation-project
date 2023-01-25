using PokemonWEB.Models;
using PokemonWEB.Models.Action;

namespace PokemonAPI;

public class PokemonAbility
{
    public Guid PokemonId { get; set; }
    public int AbilityId { get; set; }
    public Pokemon Pokemon { get; set; }
    public Ability Ability { get; set; }
}