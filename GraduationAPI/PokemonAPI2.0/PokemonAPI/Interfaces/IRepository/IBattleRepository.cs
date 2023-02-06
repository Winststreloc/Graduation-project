using PokemonAPI.Dto;
using PokemonAPI.Models;
using PokemonAPI.Models.Enums;

namespace PokemonWEB.Interfaces;

public interface IBattleRepository
{
    Task<Guid> CreateBattle(BattleCreateDto battleCreateDto);
    Task<Battle?> CreateLocalBattle(Guid pokemonId);
    Task<BattleResponceDto> MovePokemon(BattleMoveDto battleMoveDto);
    Task<BattleInfoDto?> GetBattleInfo(Guid battleId);

}