using PokemonAPI.Dto;

namespace PokemonWEB.Interfaces;

public interface IBattleRepository
{
    Task<Guid> CreateBattle(BattleCreateDto battleCreateDto);
    Task<BattleResponceDto> MovePokemon(BattleMoveDto battleMoveDto);
}