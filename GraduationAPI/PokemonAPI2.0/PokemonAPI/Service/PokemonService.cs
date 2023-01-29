using Microsoft.EntityFrameworkCore;
using PokemonAPI.Interfaces;
using PokemonWEB.Data;
using PokemonWEB.Models;

namespace PokemonAPI.Service;

public class PokemonService : IPokemonService
{
    private readonly PokemonDbContext _context;

    public PokemonService(PokemonDbContext context)
    {
        _context = context;
    }

    public async Task<bool> HealingPokemons(ICollection<Pokemon> pokemons)
    {
        foreach (var pokemon in pokemons)
        {
            pokemon.CurrentHealth = await MaxPokemonHP(pokemon.PokemonRecordId, pokemon.Level);
        }

        return await Task.FromResult(true);
    }
    
    public async Task<int> GetDamage(int pokedexId, int level)
    {
        var pokedex = await _context.Pokedex.FirstOrDefaultAsync(p => p.PokedexId == pokedexId);
        return pokedex.BaseDamage * (1 + level / 100);
    }
    
    public async Task<int> MaxPokemonHP(int pokedexId, int level)
    {
        var pokedex = await _context.Pokedex.SingleOrDefaultAsync(p => p.PokedexId == pokedexId);
        return pokedex.BaseHP * (1 + level / 100);
    }
    
    public async Task<int> GetDefence(int pokedexId, int level)
    {
        var pokedex = await _context.Pokedex.FirstOrDefaultAsync(p => p.PokedexId == pokedexId);
        return pokedex.BaseHP * (1 + level / 100);
    }
}