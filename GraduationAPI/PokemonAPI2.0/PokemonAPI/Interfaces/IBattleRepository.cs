using PokemonAPI2._0.Models.Action;
using PokemonWEB.Models;
using PokemonWEB.Models.Action;

namespace PokemonWEB.Interfaces;

public interface IBattleRepository
{
    ICollection<Pokemon> UpdateBattle(Battle battle, int abilityId);
}