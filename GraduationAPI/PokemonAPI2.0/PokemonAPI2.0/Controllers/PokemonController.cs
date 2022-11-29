using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PokemonWEB.Dto;
using PokemonWEB.Interfaces;
using PokemonWEB.Models;

namespace PokemonWEB.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PokemonController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IPokemonRepository _pokemonRepository;

    public PokemonController(IPokemonRepository pokemonRepository, IMapper mapper)
    {
        _pokemonRepository = pokemonRepository;
        _mapper = mapper;
    }
    
    [HttpGet("{pokedexId:int}")]
    [ProducesResponseType(200, Type = typeof(IEnumerable<Pokemon>))]
    [ProducesResponseType(400)]
    public IActionResult GetPokemon([FromRoute] Guid Id)
    {
        if (!_pokemonRepository.PokemonExists(Id))
        {
            return NotFound();
        }
        
        var pokemon = _mapper.Map<List<PokemonDto>>(_pokemonRepository.GetPokemon(Id));

        return Ok(pokemon);
    }

    [HttpGet("get-pokemons")]
    public IActionResult GetPokemons([FromRoute] int countPokemons)
    {
        
        return Ok();
    }

    [HttpPost]
    public IActionResult CreatePokemon([FromQuery]Guid categoryGuid, [FromQuery]Guid ownerGuid, 
        [FromBody]PokemonDto pokemonCreate)
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
        _pokemonRepository.CreatePokemon(ownerGuid, categoryGuid, pokemon);

        return Ok("Created");
    }

    [HttpPut("{pokemonId}")]
    public IActionResult UpdatePokemon([FromQuery] Guid pokemon)
    {
        return Ok();
    }
}