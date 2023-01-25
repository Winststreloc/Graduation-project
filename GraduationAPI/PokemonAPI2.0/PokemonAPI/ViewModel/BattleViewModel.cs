using PokemonWEB.Models;
using PokemonWEB.Models.Action;

namespace PokemonAPI.ViewModel;

public class BattleViewModel
{
    public Guid UserPokemonId { get; set; }
    public Guid EnemyPokemonId { get; set; }
    public int UserAbility { get; set; }
}