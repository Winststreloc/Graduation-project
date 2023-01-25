using PokemonAPI.ViewModel;

using PokemonWEB.Models;


namespace PokemonWEB.Interfaces;

public interface IBattleRepository
{
    ICollection<Pokemon> UpdateBattle(BattleViewModel battle);
    bool BattleEnded(ICollection<Pokemon> pokemons);
}