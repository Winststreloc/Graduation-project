using PokemonAPI.Dto;
using PokemonAPI.Models;

namespace PokemonWEB.Interfaces;

public interface IBattleRepository
{
    Task<Guid> CreateBattle(BattleCreateDto battleCreateDto);
    Task<Battle> CreateLocalBattle(Guid pokemonId);
    Task<BattleResponceDto> MovePokemon(BattleMoveDto battleMoveDto);
    
}