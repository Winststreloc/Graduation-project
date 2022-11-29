using PokemonWEB.Models;

namespace PokemonWEB.Interfaces;

public interface IPokedexRepository
{
    Pokemon GetPokemon(int pokedexId);
    void CreatePokemon(int pokedexId, Pokemon pokemon);
    void UpdatePokemon(Pokemon pokemon);
    void DeletePokemon(Pokemon pokemon);
    bool PokemonExists(int pokedexId);
    void Save();
}