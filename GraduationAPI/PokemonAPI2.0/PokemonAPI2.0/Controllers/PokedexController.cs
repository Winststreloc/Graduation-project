using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PokemonWEB.Dto;
using PokemonWEB.Interfaces;
using PokemonWEB.Models;

namespace PokemonWEB.Controllers;

[ApiController]
[Route("api/[controller]")]
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
    public IActionResult GetPokemon([FromQuery]int id)
    {
        if (!_pokedexRepository.PokemonExists(id))
        {
            return NotFound();
        }
        
        var pokemon = _mapper.Map<PokemonDto>(_pokedexRepository.GetPokemon(id));

        return Ok(pokemon);
    }

    [HttpGet("get-pokemons")]
    public IActionResult GetPokemons()
    {
        var pokemons = _mapper.Map<List<PokemonDto>>(_pokedexRepository.GetPokemons());
        return Ok(pokemons);
    }

    [HttpPost("create-pokemon")]
    public IActionResult CreatePokemon([FromBody] PokemonDto pokemon)
    {
        if (pokemon == null)
        {
            return BadRequest();
        }

        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        _pokedexRepository.CreatePokemon(pokemon);

        return Ok("Created");
    }

    [HttpPut("update-pokemon")]
    public IActionResult UpdatePokemon([FromBody]PokemonDto updatedPokemon)
    {
        if (updatedPokemon == null)
            return BadRequest(ModelState);

        if (!ModelState.IsValid)
            return BadRequest();

        if (!_pokedexRepository.UpdatePokemon(updatedPokemon))
        {
            ModelState.AddModelError("", "Something went wrong updating owner");
            return StatusCode(500, ModelState);
        }

        return NoContent();
    }

    [HttpDelete("delete-pokemon")]
    public IActionResult DeletePokemon([FromQuery]int pokemonId)
    {
        if (!_pokedexRepository.PokemonExists(pokemonId))
        {
            return NotFound();
        }
        
        var pokemonToDelete = _pokedexRepository.GetPokemon(pokemonId);

        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        

        if (!_pokedexRepository.DeletePokemon(pokemonToDelete))
        {
            ModelState.AddModelError("", "Something went wrong deleting owner");
        }
        return NoContent();
    }
}