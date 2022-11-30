using PokemonWEB.Dto;
using PokemonWEB.Models;
using PokemonWEB.Models.Action;

namespace PokemonWEB.Interfaces;

public interface IPokedexRepository
{
    PokemonDto GetPokemon(int Id);
    ICollection<PokemonDto> GetPokemons();
    void CreatePokemon(PokemonDto pokemon);
    bool UpdatePokemon(PokemonDto pokemon);
    bool DeletePokemon(PokemonDto pokemon);
    bool PokemonExists(int Id);
    bool Save();
}