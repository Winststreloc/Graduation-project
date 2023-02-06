using PokemonWEB.Models;
using PokemonWEB.Models.Action;

namespace PokemonAPI.Dto;

public class BattleInfoDto
{
    public Pokemon AttackPokemon { get; set; }
    public Pokemon DefendingPokemon { get; set; }
    public ICollection<Ability> Abilities { get; set; }
}