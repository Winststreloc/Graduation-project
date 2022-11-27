using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PokemonWEB.Dto;
using PokemonWEB.Interfaces;
using PokemonWEB.Models;

namespace PokemonWEB.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PokemonController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IPokemonRepository _pokemonRepository;

    public PokemonController(IPokemonRepository pokemonRepository, IMapper mapper)
    {
        _pokemonRepository = pokemonRepository;
        _mapper = mapper;
    }
    
    [HttpGet]
    [ProducesResponseType(200, Type = typeof(IEnumerable<Pokemon>))]
    [ProducesResponseType(400)]
    public IActionResult GetPokemons([FromRoute]int pokedexId)
    {
        if (_pokemonRepository.PokemonExists(pokedexId))
        {
            return NotFound();
        }

        var pokemon = _pokemonRepository.GetPokemon(pokedexId);
        //var pokemon = _mapper.Map<List<PokemonDto>>(_pokemonRepository.GetPokemon(pokedexId));

        return Ok(pokemon);
    }
    
}