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
    public async Task<IActionResult> GetPokemon([FromQuery]int id)
    {
        if (!_pokedexRepository.PokemonExists(id))
        {
            return NotFound();
        }
        
        var pokemon = await _mapper.Map<Task<PokedexDto>>(_pokedexRepository.GetPokemon(id));
        return Ok(pokemon);
    }

    [HttpGet("get-pokemons-from-pokedex")]
    public IActionResult GetPokemons()
    {
        var pokemons = _mapper.Map<List<PokedexDto>>(_pokedexRepository.GetPokemons());
        return Ok(pokemons);
    }

    [HttpPost("create-pokedex-pokemon")]
    public IActionResult CreatePokemon([FromBody] PokedexDto pokemon)
    {
        if (pokemon == null)
        {
            return BadRequest();
        }

        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        _pokedexRepository.CreatePokemon(_mapper.Map<Pokedex>(pokemon));

        return Ok("Created");
    }

    [HttpPut("update-pokedex-pokemon")]
    public IActionResult UpdatePokemon([FromBody]PokedexDto updatedPokemon)
    {
        if (updatedPokemon == null)
            return BadRequest(ModelState);

        if (!ModelState.IsValid)
            return BadRequest();
        
        _pokedexRepository.UpdatePokemon(_mapper.Map<Pokedex>(updatedPokemon));
        
        return NoContent();
    }

    [HttpDelete("delete-pokedex-pokemon")]
    public IActionResult DeletePokemon([FromQuery]int pokemonId)
    {
        if (!_pokedexRepository.PokemonExists(pokemonId))
        {
            return NotFound();
        }
        
        var pokemonToDelete = _pokedexRepository.GetPokemon(pokemonId);

        if (!ModelState.IsValid)
            return BadRequest(ModelState);


        _pokedexRepository.DeletePokemon(_mapper.Map<Pokedex>(pokemonToDelete));
        return NoContent();
    }
}