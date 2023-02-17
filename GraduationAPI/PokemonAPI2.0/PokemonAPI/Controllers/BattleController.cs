using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PokemonAPI.Dto;
using PokemonAPI.Interfaces;
using PokemonAPI.Models;
using PokemonWEB.Interfaces;

namespace PokemonWEB.Controllers;

[ApiController]
[Route("[controller]")]
[Authorize]
public class BattleController : ControllerBase
{
    private readonly IBattleRepository _battleRepository;
    private readonly IBattleService _battleService;
    private readonly IMapper _mapper;

    public BattleController(IBattleRepository battleRepository, IMapper mapper, IBattleService battleService)
    {
        _mapper = mapper;
        _battleService = battleService;
        _battleRepository = battleRepository;
    }

    [HttpGet("get-battle-info")]
    public async Task<BattleInfoDto?> GetBattleInfo([FromQuery] Guid battleId, [FromQuery]Guid userId)
    {
        return await _battleRepository.GetBattleInfo(battleId, userId);
    }

    [HttpPost("create-battle")]
    public async Task<Guid> CreateBattle([FromBody] BattleCreateDto battle)
    {
        return await _battleRepository.CreateBattle(battle);
    }

    [HttpPost("create-local-battle")]
    public async Task<Battle?> CreateLocalBattle([FromQuery]Guid pokemonId)
    {
        return await _battleService.CreateLocalBattle(pokemonId);
    }

    [HttpPost("update-battle")]
    public async Task<BattleResponceDto> MovePokemon(BattleMoveDto battleUpdateDto)
    {
        return await _battleService.UpdatePokemon(battleUpdateDto);
    }
}