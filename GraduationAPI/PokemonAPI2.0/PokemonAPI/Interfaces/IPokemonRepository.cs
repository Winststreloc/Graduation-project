using PokemonWEB.Models;

namespace PokemonWEB.Interfaces;

public interface IPokemonRepository
{
    Pokemon GetPokemon(Guid Id);
    ICollection<Pokemon> GetPokemons(int countPokemon);

    void CreatePokemon(Guid ownerId, Guid categoryId, Pokemon pokemon);
    bool UpdatePokemon(Guid ownerId, Guid categoryId, Pokemon pokemon);
    bool DeletePokemon(Pokemon pokemon);
    bool PokemonExists(Guid Id);
}