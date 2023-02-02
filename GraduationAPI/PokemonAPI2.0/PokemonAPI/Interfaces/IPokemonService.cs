using PokemonWEB.Models;

namespace PokemonAPI.Interfaces;

public interface IPokemonService
{
    Task<int> HealingPokemons(ICollection<Pokemon> pokemons);
    Task<int> GetDamage(int pokedexId, int level);
    Task<int> MaxPokemonHP(int pokedexId, int level);
    Task<int> GetDefence(int pokedexId, int level);
}