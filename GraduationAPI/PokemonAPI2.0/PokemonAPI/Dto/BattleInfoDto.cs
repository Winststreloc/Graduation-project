using PokemonWEB.Models;
using PokemonWEB.Models.Action;

namespace PokemonAPI.Dto;

public class BattleInfoDto
{
    public Pokemon UserPokemon { get; set; }
    public Pokemon EnemyPokemon { get; set; }
    public bool Queue { get; set; }
    public ICollection<Ability> UserPokemonAbilities { get; set; }
}