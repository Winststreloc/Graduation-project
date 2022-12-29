using PokemonAPI2._0.Models.Action;
using PokemonWEB.Models;
using PokemonWEB.Models.Action;

namespace PokemonWEB.Interfaces;

public interface IBattleRepository
{
    Battle GetBattle(Guid id);
    void CreateBattle(Guid pokemonId, int pokedexIdEnemy);
    bool UpdateBattle(Guid battleId, Ability ability);
    bool DeleteBattle(Guid battleId);
    bool BattleExists(Guid Id);
}