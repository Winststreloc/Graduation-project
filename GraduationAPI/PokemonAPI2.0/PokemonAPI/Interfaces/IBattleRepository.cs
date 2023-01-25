using PokemonAPI.ViewModel;

using PokemonWEB.Models;


namespace PokemonWEB.Interfaces;

public interface IBattleRepository
{
    ICollection<Pokemon> UpdateBattle(BattleViewDto battle);
    bool BattleEnded(ICollection<Pokemon> pokemons);
}