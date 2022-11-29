using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PokemonWEB.Dto;
using PokemonWEB.Interfaces;
using PokemonWEB.Models;

namespace PokemonWEB.Controllers;

public class PokedexController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IPokedexRepository _pokedexRepository;

    public PokedexController(IPokedexRepository pokedexRepository, IMapper mapper)
    {
        _pokedexRepository = pokedexRepository;
        _mapper = mapper;
    }
    
    [HttpGet("{pokedexId:int}")]
    [ProducesResponseType(200, Type = typeof(IEnumerable<Pokemon>))]
    [ProducesResponseType(400)]
    public IActionResult GetPokemon([FromRoute] int pokedexId)
    {

        //var pokemon = _pokemonRepository.GetPokemon(pokedexId);
        var pokemon = _mapper.Map<List<PokemonDto>>(_pokedexRepository.GetPokemon(pokedexId));

        return Ok(pokemon);
    }
}