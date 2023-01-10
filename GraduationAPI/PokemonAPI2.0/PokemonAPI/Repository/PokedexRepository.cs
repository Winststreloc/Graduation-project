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

    public async Task<Pokedex> GetPokemon(int id)
    {
        return await _context.Pokedex.FirstOrDefaultAsync(p => p.PokedexId == id);
    }

    public ICollection<Pokedex> GetPokemons()
    {
        return _context.Pokedex.OrderBy(p => p.PokedexId).ToList();
    }

    public bool CreatePokemon(Pokedex pokemon)
    {
        _context.AddAsync(pokemon);
        return Save();
    }

    public bool UpdatePokemon(Pokedex pokemon)
    {
        _context.Update(pokemon);
        return Save();
    }

    public bool DeletePokemon(Pokedex pokemon)
    {
        _context.Remove(pokemon);
        return Save();
    }

    public bool PokemonExists(int id)
    {
        return _context.Pokedex.Any(p => p.PokedexId == id);
    }
    
    public bool Save()
    {
        var saved = _context.SaveChangesWithIdentityInsert<Pokedex>();
        return saved > 0;
    }
}