using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PokemonWEB.Dto;
using PokemonWEB.Interfaces;
using PokemonWEB.Models;

namespace PokemonWEB.Controllers;

[ApiController]
[Route("[controller]")]
public class PokemonController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IPokemonRepository _pokemonRepository;

    public PokemonController(IPokemonRepository pokemonRepository, IMapper mapper)
    {
        _pokemonRepository = pokemonRepository;
        _mapper = mapper;
    }

    [HttpGet("pokemonId")]
    public IActionResult GetPokemon([FromQuery] Guid Id)
    {
        if (!_pokemonRepository.PokemonExists(Id))
        {
            return NotFound();
        }
        
        var pokemon = _mapper.Map<PokemonDto>(_pokemonRepository.GetPokemon(Id));

        return Ok(pokemon);
    }

    [HttpGet("get-pokemons")]
    [Authorize]
    public IActionResult GetPokemons([FromQuery] int countPokemons)
    {
        var pokemons = _mapper.Map<List<PokemonDto>>(_pokemonRepository.GetPokemons(countPokemons));
        return Ok(pokemons);
    }

    [HttpGet("get-user-pokemons")]
    public async Task<ICollection<Pokemon>> GetUserPokemons([FromQuery] Guid userId)
    {
        return await _pokemonRepository.GetUserPokemons(userId);
    }

    [HttpPut("healing-user-pokemons")]
    public async Task<IActionResult> HealingUserPokemons([FromQuery] Guid userId)
    {
        var result = await _pokemonRepository.HealingUserPokemons(userId);
        return result ? Ok() : NoContent();
    }

    [HttpPost("create-pokemon")]
    public async Task<IActionResult> CreatePokemon([FromQuery] int categoryId, [FromQuery] Guid userId,
        [FromBody] PokemonDto pokemonCreate)
    {
        if (pokemonCreate == null)
        {
            return BadRequest();
        }

        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var pokemon = _mapper.Map<Pokemon>(pokemonCreate);
        if (!await _pokemonRepository.CreatePokemon(userId, categoryId, pokemon))
        {
            ModelState.AddModelError("", "Something went wrong deleting owner");
        }

        return Ok("Created");
    }
    
    [HttpPut("update-pokemon")]
    public IActionResult UpdatePokemon([FromQuery] Guid pokemonId, [FromQuery] int pokedexId, [FromQuery] Guid ownerId,
        [FromQuery] int categoryId, [FromBody]PokemonDto updatedPokemon)
    {
        if (updatedPokemon == null)
            return BadRequest(ModelState);

        if (pokedexId != updatedPokemon.PokemonRecordId)
            return BadRequest(ModelState);

        if (!_pokemonRepository.PokemonExists(pokemonId))
            return NotFound();

        if (!ModelState.IsValid)
            return BadRequest();

        var pokemonMap = _mapper.Map<Pokemon>(updatedPokemon);

        _pokemonRepository.UpdatePokemon(ownerId, categoryId, pokemonMap);

        return NoContent();
    }

    [HttpDelete("delete-pokemon")]
    public IActionResult DeletePokemon([FromQuery]Guid pokemonId)
    {
        if (!_pokemonRepository.PokemonExists(pokemonId))
        {
            return NotFound();
        }
        
        var pokemonToDelete = _pokemonRepository.GetPokemon(pokemonId);

        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        

        if (!_pokemonRepository.DeletePokemon(pokemonToDelete))
        {
            ModelState.AddModelError("", "Something went wrong deleting owner");
        }
        return NoContent();
    }
}