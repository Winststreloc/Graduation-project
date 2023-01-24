using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PokemonAPI.ViewModel;
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

    public BattleController(IBattleRepository battleRepository)
    {
        _battleRepository = battleRepository;
    }

    [HttpPut]
    public IActionResult UpdateBattle([FromQuery]BattleViewModel battle)
    {
        var pokemons = _battleRepository.UpdateBattle(battle);
        return Ok(pokemons);
    }
}