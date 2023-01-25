using PokemonWEB.Models;

namespace PokemonAPI.ViewModel;

public class ResponceBattle
{
    public ICollection<Pokemon> Pokemons { get; set; }
    public bool BattleEnded { get; set; }
}