using PokemonAPI.Dto;
using PokemonWEB.Models;
using PokemonWEB.Models.Action;

namespace PokemonAPI.Interfaces;

public interface IBattleService
{
    Task<BattleResponceDto> MovePokemon(Pokemon? attackPokemon, Pokemon? defendingPokemon, Ability? ability);
    Task<Guid> GenerateRandomPokemon();
    Task<Ability?> GetRandomPokemonAbility(Guid pokemonId);
}