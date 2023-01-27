using PokemonAPI.Dto;

namespace PokemonWEB.Interfaces;

public interface IBattleRepository
{
    Task<Guid> CreateBattle(BattleCreateDto battleCreateDto);
    Task<Guid> CreateLocalBattle(Guid pokemonId);
    Task<BattleResponceDto> MovePokemon(BattleMoveDto battleMoveDto);
    
}