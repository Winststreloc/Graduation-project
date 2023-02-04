using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PokemonAPI.Dto;
using PokemonWEB.Dto;
using PokemonWEB.Interfaces;
using PokemonWEB.Models;

namespace PokemonWEB.Controllers;

[ApiController]
[Route("[controller]")]
[Authorize]
public class PokemonController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IPokemonRepository _pokemonRepository;

    public PokemonController(IPokemonRepository pokemonRepository, IMapper mapper)
    {
        _pokemonRepository = pokemonRepository;
        _mapper = mapper;
    }

    [HttpGet("get-pokemon")]
    public async Task<Pokemon> GetPokemon([FromQuery]Guid id)
    {
        return await _pokemonRepository.GetPokemon(id);
    }

    [HttpGet("get-pokemons")]
    public IActionResult GetPokemons([FromQuery] int countPokemons)
    {
        var pokemons = _pokemonRepository.GetPokemons(countPokemons);
        return Ok(pokemons);
    }

    [HttpGet("get-user-pokemons")]
    public async Task<ICollection<Pokemon>> GetUserPokemons([FromQuery]Guid userId)
    {
        return await _pokemonRepository.GetUserPokemons(userId);
    }

    [HttpGet("get-pokemon-ability-and-category")]
    public async Task<PokemonAbilityCategoryDto> GetPokemonAbilityCategory([FromQuery]Guid id)
    {
        return await _pokemonRepository.GetPokemonAbilityCategory(id);
    }

    [HttpPut("healing-user-pokemons")]
    public async Task<int> HealingUserPokemons([FromQuery] Guid userId)
    {
        return await _pokemonRepository.HealingUserPokemons(userId);;
    }

    [HttpPost("create-pokemon")]
    public async Task<IActionResult> CreatePokemon([FromQuery] int categoryId, [FromQuery] Guid userId,
        [FromBody]Pokemon? pokemonCreate)
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
        [FromQuery] int categoryId, [FromBody]Pokemon? updatedPokemon)
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
    public async Task<IActionResult> DeletePokemon([FromQuery]Guid pokemonId)
    {
        if (!_pokemonRepository.PokemonExists(pokemonId))
        {
            return NotFound();
        }
        
        var pokemonToDelete = await _pokemonRepository.GetPokemon(pokemonId);

        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        

        if (!_pokemonRepository.DeletePokemon(pokemonToDelete))
        {
            ModelState.AddModelError("", "Something went wrong deleting owner");
        }
        return NoContent();
    }

    [HttpGet("super-secret-method")]
    public async Task<int> UpdateAllPokemons()
    {
        return await _pokemonRepository.UpdateAllPokemons();
    }
}