using AutoMapper;
using PokemonAPI2._0.Migrations;
using PokemonWEB.Data;
using PokemonWEB.Dto;
using PokemonWEB.Interfaces;
using PokemonWEB.Models;

namespace PokemonWEB.Repository;

public class PokedexRepository : IPokedexRepository
{
    private readonly PokemonDbContext _context;
    private readonly IMapper _mapper;
    
    public PokedexRepository(PokemonDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public PokemonDto GetPokemon(int id)
    {
        return _mapper.Map<PokemonDto>(_context.Pokedex.FirstOrDefault(p => p.Id == id));
    }

    public ICollection<PokemonDto> GetPokemons()
    {
        return _mapper.Map<List<PokemonDto>>(_context.Pokemon.OrderBy(p => p.PokedexId).ToList());
    }

    public void CreatePokemon(PokemonDto pokemon)
    {
        _context.Add(pokemon);
        Save();
    }

    public bool UpdatePokemon(PokemonDto pokemon)
    {
        _context.Update(pokemon);
        return Save();
    }

    public bool DeletePokemon(PokemonDto pokemon)
    {
        _context.Remove(pokemon);
        return Save();
    }

    public bool PokemonExists(int id)
    {
        return _context.Pokedex.Any(p => p.Id == id);
    }


    public bool Save()
    {
        var saved = _context.SaveChanges();
        return saved > 0;
    }
}