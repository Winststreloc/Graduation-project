using PokemonAPI2._0.Models.Action;
using PokemonWEB.Models;
using PokemonWEB.Models.Action;

namespace PokemonAPI.Service;

public interface ILocalBattleService
{
    ICollection<Pokemon> UpdateBattle(Pokemon pokemonUser, Pokemon pokemonEnemy, Ability moveUser);
}