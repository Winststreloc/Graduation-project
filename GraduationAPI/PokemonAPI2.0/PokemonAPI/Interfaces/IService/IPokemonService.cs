using PokemonWEB.Models;

namespace PokemonAPI.Interfaces;

public interface IPokemonService
{
    Task<Pokemon> CreatePokemon(PokemonRecord pokeRecord, User computerUser);
    Task<int> HealingPokemons(ICollection<Pokemon?> pokemons);
    int HealingPokemon(Pokemon pokemon);
    Task<int> GetDamage(int pokedexId, int level);
    Task<int> MaxPokemonHP(int pokedexId, int level);
    Task<int> GetDefence(int pokedexId, int level);
}