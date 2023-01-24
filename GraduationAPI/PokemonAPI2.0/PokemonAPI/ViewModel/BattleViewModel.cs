using PokemonWEB.Models;
using PokemonWEB.Models.Action;

namespace PokemonAPI.ViewModel;

public class BattleViewModel
{
    public Pokemon UserPokemon { get; set; }
    public Pokemon EnemyPokemon { get; set; }
    public int UserAbility { get; set; }
}