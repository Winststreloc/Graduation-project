using PokemonAPI.Dto;
using PokemonWEB.Models;
using PokemonWEB.Models.Action;

namespace PokemonAPI.Interfaces;

public interface IBattleService
{
    BattleResponceDto MovePokemon(Pokemon pokemon1, Pokemon pokemon2, Ability ability);
}