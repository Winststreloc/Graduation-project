using PokemonAPI.Dto;
using PokemonAPI.Models;
using PokemonAPI.Models.Enums;

namespace PokemonWEB.Interfaces;

public interface IBattleRepository
{
    Task<Guid> CreateBattle(BattleCreateDto battleCreateDto);
    Task<BattleInfoDto?> GetBattleInfo(Guid battleId);
    Task<Battle> GetValidBattle(Guid battleId);
    Task UpdateBattle(Battle battle);
    Task DeleteBattle(Battle battle);
    Task AddBattle(Battle battle);
}