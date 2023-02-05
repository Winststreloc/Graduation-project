using PokemonAPI.Dto;
using PokemonWEB.Models;
using PokemonWEB.Models.Action;

namespace PokemonWEB.Interfaces;

public interface IPokemonRepository
{
    Task<Pokemon> GetPokemon(Guid Id);
    ICollection<Pokemon> GetPokemons(int countPokemon);
    ICollection<Ability> GetPokemonAbilities(Guid pokemonId);
    Task<ICollection<Pokemon>> GetUserPokemons(Guid userId);
    Task<PokemonAbilityCategoryDto> GetPokemonAbilityCategory(Guid pokemonId);
    Task<int> HealingUserPokemons(Guid userId);
    Task<int> HealingPokemon(Guid pokemonId);
    Task<bool> IsComputerPokemon(Pokemon? pokemon);
    Task<bool> CreatePokemon(Guid userId, int categoryId, Pokemon pokemon);
    bool UpdatePokemon(Guid ownerId, int categoryId, Pokemon pokemon);
    bool DeletePokemon(Pokemon pokemon);
    bool PokemonExists(Guid Id);
    Task<int> UpdateAllPokemons();
}