using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PokemonAPI.Dto;
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
    public async Task<Guid> BattleCreate([FromBody] BattleCreateDto battle)
    {
        return await _battleRepository.CreateBattle(battle);
    }

    [HttpPost("update-battle")]
    public async Task<BattleResponceDto> MovePokemon(BattleMoveDto battleUpdateDto)
    {
        return await _battleRepository.MovePokemon(battleUpdateDto);
    }
}