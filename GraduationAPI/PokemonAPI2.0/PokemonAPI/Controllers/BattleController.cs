using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PokemonAPI2._0.Models.Action;
using PokemonWEB.Data;
using PokemonWEB.Interfaces;
using PokemonWEB.Models;
using PokemonWEB.Models.Action;

namespace PokemonWEB.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BattleController : Controller
{
    private readonly IBattleRepository _battleRepository;
    private readonly IMapper _mapper;

    public BattleController(IMapper mapper, IBattleRepository battleRepository)
    {
        _mapper = mapper;
        _battleRepository = battleRepository;
    }

    [HttpPut]
    public IActionResult UpdateBattle([FromBody]Battle battle, int abilityId)
    {
        var pokemons = _battleRepository.UpdateBattle(battle, abilityId);
        return Ok(pokemons);
    }
}