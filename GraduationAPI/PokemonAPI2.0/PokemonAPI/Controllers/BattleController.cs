using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PokemonAPI.ViewModel;
using PokemonWEB.Data;
using PokemonWEB.Interfaces;
using PokemonWEB.Models;
using PokemonWEB.Models.Action;

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

    [HttpPut]
    public IActionResult UpdateBattle([FromBody]BattleViewDto battle)
    {
        var pokemons = _battleRepository.UpdateBattle(battle);
        var battleEnded = _battleRepository.BattleEnded(pokemons);
        ResponceBattle responce = new ResponceBattle()
        {
            Pokemons = pokemons,
            BattleEnded = battleEnded
        };
        return Ok(responce);
    }
}