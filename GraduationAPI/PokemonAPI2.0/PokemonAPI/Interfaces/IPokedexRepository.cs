using PokemonWEB.Dto;
using PokemonWEB.Models;

namespace PokemonWEB.Interfaces;

public interface IPokedexRepository
{
    Task<Pokedex> GetPokemon(int id);
    ICollection<Pokedex> GetPokemons();
    bool CreatePokemon(Pokedex pokemon);
    bool UpdatePokemon(Pokedex pokemon);
    bool DeletePokemon(Pokedex pokemon);
    bool PokemonExists(int id);
}