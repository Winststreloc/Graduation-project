using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PokemonWEB.Data;
using PokemonWEB.Interfaces;
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

    [HttpGet]
    public IActionResult GetBattle([FromQuery]Guid id)
    {
        if (!_battleRepository.BattleExists(id))
        {
            return NotFound();
        }

        var battle = _battleRepository.GetBattle(id);
        return Ok(battle);
    }

    [HttpPost]
    public IActionResult CreateBattle([FromQuery]Guid pokemonUserId, [FromQuery]int pokedexIdEnemy)
    {
        _battleRepository.CreateBattle(pokemonUserId, pokedexIdEnemy);
        return Ok("Created");
    }

    [HttpPut]
    public IActionResult UpdateBattle(Guid battle, Ability ability)
    {
        _battleRepository.UpdateBattle(battle, ability);
        return NoContent();
    }

    [HttpDelete]
    public IActionResult DeleteBattle([FromBody]Guid battleId)
    {
        _battleRepository.DeleteBattle(battleId);
        return NoContent();
    }
}