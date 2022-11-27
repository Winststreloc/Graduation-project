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
    public IActionResult GetPokemon([FromRoute] int pokedexId)
    {
        if (!_pokemonRepository.PokemonExists(pokedexId))
        {
            return NotFound();
        }
        
        //var pokemon = _pokemonRepository.GetPokemon(pokedexId);
        var pokemon = _mapper.Map<List<PokemonDto>>(_pokemonRepository.GetPokemon(pokedexId));

        return Ok(pokemon);
    }

    [HttpPost]
    public IActionResult CreatePokemon([FromQuery]string categoryGuid, [FromQuery]string ownerGuid, 
        [FromBody]PokemonDto pokemonCreate)
    {
        // if (pokemonCreate == null)
        // {
        //     return BadRequest();
        // }
        
        // if (!ModelState.IsValid)
        // {
        //     return BadRequest(ModelState);
        // }

        var pokemon = _mapper.Map<Pokemon>(pokemonCreate);
        _pokemonRepository.CreatePokemon(ownerGuid, categoryGuid, pokemon);
        
        return Ok("Created");
        
    }
}