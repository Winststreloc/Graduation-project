using PokemonAPI.Dto;
using PokemonWEB.Models;
using PokemonWEB.Models.Action;

namespace PokemonAPI.Interfaces;

public interface IBattleService
{
    BattleResponceDto MovePokemon(Pokemon? pokemon1, Pokemon? pokemon2, Ability? ability);
    Task<Pokemon> GenerateRandomPokemon();
    Task<Ability?> GetRandomPokemonAbility(Guid pokemonId);
}