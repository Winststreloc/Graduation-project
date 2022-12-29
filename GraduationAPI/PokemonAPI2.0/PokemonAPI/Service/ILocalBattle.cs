using PokemonAPI2._0.Models.Action;
using PokemonWEB.Models.Action;

namespace PokemonAPI.Service;

public interface ILocalBattle
{
    bool UpdateBattle(Battle battle, Ability moveUser);
}