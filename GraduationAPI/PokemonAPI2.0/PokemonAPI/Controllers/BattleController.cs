using Microsoft.AspNetCore.Mvc;
using PokemonAPI.ViewModel;
using PokemonWEB.Interfaces;

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
    public IActionResult UpdateBattle([FromBody]BattleViewModel battle)
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