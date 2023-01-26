using PokemonWEB.Dto;
using PokemonWEB.Models;

namespace PokemonWEB.Interfaces;

public interface IPokedexRepository
{
    PokemonRecord GetPokemon(int id);
    ICollection<PokemonRecord> GetPokemons();
    bool CreatePokemon(PokemonRecord pokemon);
    bool UpdatePokemon(PokemonRecord pokemon);
    bool DeletePokemon(PokemonRecord pokemon);
    bool PokemonExists(int id);
}