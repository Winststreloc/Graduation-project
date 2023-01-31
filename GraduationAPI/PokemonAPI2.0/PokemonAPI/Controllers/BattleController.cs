using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PokemonAPI.Dto;
using PokemonAPI.Models;
using PokemonWEB.Interfaces;

namespace PokemonWEB.Controllers;

[ApiController]
[Route("[controller]")]
public class BattleController : ControllerBase
{
    private readonly IBattleRepository _battleRepository;
    private readonly IMapper _mapper;

    public BattleController(IBattleRepository battleRepository, IMapper mapper)
    {
        _mapper = mapper;
        _battleRepository = battleRepository;
    }

    [HttpPost("create-battle")]
    public async Task<Guid> CreateBattle([FromBody] BattleCreateDto battle)
    {
        return await _battleRepository.CreateBattle(battle);
    }

    [HttpPost("create-local-battle")]
    public async Task<Battle> CreateLocalBattle([FromQuery]Guid pokemonId)
    {
        return await _battleRepository.CreateLocalBattle(pokemonId);
    }

    [HttpPost("update-battle")]
    public async Task<BattleResponceDto> MovePokemon(BattleMoveDto battleUpdateDto)
    {
        return await _battleRepository.MovePokemon(battleUpdateDto);
    }
}