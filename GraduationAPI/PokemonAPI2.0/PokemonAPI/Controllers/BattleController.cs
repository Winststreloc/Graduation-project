using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PokemonAPI2._0.Models.Action;
using PokemonWEB.Interfaces;

namespace PokemonWEB.Controllers;

[ApiController]
[Route("[controller]")]
public class BattleController : ControllerBase
{
    private readonly IBattleRepository _battleRepository;
    private readonly IMapper _mapper;

    public BattleController(IMapper mapper, IBattleRepository battleRepository)
    {
        _mapper = mapper;
        _battleRepository = battleRepository;
    }

    [HttpPut]
    public IActionResult UpdateBattle([FromBody]Battle battle, Guid abilityId)
    {
        var pokemons = _battleRepository.UpdateBattle(battle, abilityId);
        return Ok(pokemons);
    }
}