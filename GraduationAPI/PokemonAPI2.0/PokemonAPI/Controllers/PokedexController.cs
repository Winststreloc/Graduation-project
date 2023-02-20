using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PokemonWEB.Interfaces;
using PokemonWEB.Models;

namespace PokemonWEB.Controllers;

[ApiController]
[Route("[controller]")]
[Authorize]
public class PokedexController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IPokedexRepository _pokedexRepository;

    public PokedexController(IPokedexRepository pokedexRepository, IMapper mapper)
    {
        _pokedexRepository = pokedexRepository;
        _mapper = mapper;
    }

    [HttpGet("pokemonId")]
    public async Task<PokemonRecord?> GetPokemon([FromQuery]int id)
    {
        return await _pokedexRepository.GetPokemonRecord(id);
    }

    [HttpGet("get-pokemons-from-pokedex")]
    public IActionResult GetPokemons()
    {
        var pokemons = _pokedexRepository.GetPokemons();
        return Ok(pokemons);
    }

    [HttpPost("create-pokedex-pokemon-record")]
    [Authorize]
    public IActionResult CreatePokemonRecord([FromBody] PokemonRecord pokemonRecord)
    {
        if (pokemonRecord == null)
        {
            return BadRequest();
        }

        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        _pokedexRepository.CreatePokemon(_mapper.Map<PokemonRecord>(pokemonRecord));

        return Ok("Created");
    }

    [HttpPut("update-pokedex-pokemon")]
    [Authorize]
    public IActionResult UpdatePokemon([FromBody]PokemonRecord? pokemonRecord)
    {
        if (pokemonRecord == null)
            return BadRequest(ModelState);

        if (!ModelState.IsValid)
            return BadRequest();
        
        _pokedexRepository.UpdatePokemon(_mapper.Map<PokemonRecord>(pokemonRecord));
        
        return NoContent();
    }

    [HttpDelete("delete-pokedex-pokemon")]
    [Authorize]
    public IActionResult DeletePokemon([FromQuery]int pokemonId)
    {
        if (!_pokedexRepository.PokemonExists(pokemonId))
        {
            return NotFound();
        }
        
        var pokemonToDelete = _pokedexRepository.GetPokemonRecord(pokemonId);

        if (!ModelState.IsValid)
            return BadRequest(ModelState);


        _pokedexRepository.DeletePokemon(_mapper.Map<PokemonRecord>(pokemonToDelete));
        return NoContent();
    }
}