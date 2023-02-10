using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PokemonAPI.Helpers;
using PokemonWEB.Data;
using PokemonWEB.Dto;
using PokemonWEB.Interfaces;
using PokemonWEB.Models;

namespace PokemonWEB.Repository;

public class PokedexRepository : IPokedexRepository
{
    private readonly PokemonDbContext _context;

    public PokedexRepository(PokemonDbContext context)
    {
        _context = context;
    }

    public async Task<PokemonRecord?> GetPokemonRecord(int id)
    {
        return await _context.Pokedex
            .Where(p => p.Id == id)
            .Include(p => p.PokemonRecordCategories)
            .ThenInclude(prc => prc.Category)
            .SingleOrDefaultAsync();
    }


    public ICollection<PokemonRecord> GetPokemons()
    {
        return _context.Pokedex.OrderBy(p => p.Id).ToList();
    }

    public bool CreatePokemon(PokemonRecord pokemon)
    {
        _context.AddAsync(pokemon);
        return Save();
    }

    public bool UpdatePokemon(PokemonRecord pokemon)
    {
        _context.Update(pokemon);
        return Save();
    }

    public bool DeletePokemon(PokemonRecord pokemon)
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
        var saved = _context.SaveChangesWithIdentityInsert<PokemonRecord>();
        return saved > 0;
    }
}