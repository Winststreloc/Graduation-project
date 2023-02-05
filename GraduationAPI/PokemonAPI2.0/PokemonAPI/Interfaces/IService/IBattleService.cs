using PokemonAPI.Dto;
using PokemonAPI.Models;
using PokemonWEB.Models;
using PokemonWEB.Models.Action;

namespace PokemonAPI.Interfaces;

public interface IBattleService
{
    Task<(BattleResponceDto, Battle)> MovePokemon(Pokemon? attackPokemon, Pokemon? defendingPokemon, Ability? ability, Battle battle);
    Task<Guid> GenerateRandomPokemon();
    Task<Ability?> GetRandomPokemonAbility(Guid pokemonId);
}