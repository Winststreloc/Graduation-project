using PokemonWEB.Models;
using PokemonWEB.Models.Action;

namespace PokemonWEB.Interfaces;

public interface IPokemonRepository
{
    Pokemon GetPokemon(Guid Id);
    ICollection<Pokemon> GetPokemons(int countPokemon);
    IQueryable<Ability> GetPokemonAbilities(Guid pokemonId);

    void CreatePokemon(Guid userId, int categoryId, Pokemon pokemon);
    bool UpdatePokemon(Guid ownerId, int categoryId, Pokemon pokemon);
    bool DeletePokemon(Pokemon pokemon);
    bool PokemonExists(Guid Id);
}