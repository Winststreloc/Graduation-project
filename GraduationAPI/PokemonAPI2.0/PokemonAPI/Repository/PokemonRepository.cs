using Microsoft.EntityFrameworkCore;
using PokemonAPI.Interfaces;
using PokemonWEB.Data;
using PokemonWEB.Interfaces;
using PokemonWEB.Models;
using PokemonWEB.Models.Action;

namespace PokemonWEB.Repository;

public class PokemonRepository : IPokemonRepository
{
    private readonly PokemonDbContext _context;
    private readonly IPokemonService _pokemonService;
    
    public PokemonRepository(PokemonDbContext context, IPokemonService pokemonService)
    {
        _context = context;
        _pokemonService = pokemonService;
    }

    public Pokemon GetPokemon(Guid Id)
    {
        return _context.Pokemons.FirstOrDefault(p => p.Id == Id);
    }

    public ICollection<Pokemon> GetPokemons(int count)
    {
        return _context.Pokemons.Take(count).OrderBy(p => p.PokemonRecordId).ToList();
    }

    public IQueryable<Ability> GetPokemonAbilities(Guid pokemonId)
    {
        var pokemon = _context.Pokemons.SingleOrDefault(p => p.Id == pokemonId);
        var abilities = _context.PokemonAbilities
            .Where(pa => pa.PokemonId == pokemon.Id)
            .Select(p => p.Ability).Take(4);
        return abilities;
    }
    public async Task<ICollection<Pokemon>> GetUserPokemons(Guid userId)
    {
        return await _context.Pokemons.Where(p => p.UserId == userId).ToListAsync();
    }


    public async Task<bool> HealingUserPokemons(Guid userId)
    {
        var pokemons = await GetUserPokemons(userId);
        return await _pokemonService.HealingPokemons(pokemons);
    }

    public bool PokemonExists(Guid Id)
    {
        return _context.Pokemons.Any(p => p.Id == Id);
    }

    public bool DeletePokemon(Pokemon pokemon)
    {
        _context.Remove(pokemon);
        return Save();
    }

    public void CreatePokemon(Guid userId, int categoryId, Pokemon pokemon)
    {
        var pokemonOwnerEntity = _context.Users.FirstOrDefault(o => o.Id == userId);
        var category = _context.Categories.FirstOrDefault(o => o.Id == categoryId);

        var pokemonCategory = new PokemonCategory
        {
            Category = category,
            Pokemon = pokemon
        };

        pokemon.User = pokemonOwnerEntity;
        
        _context.Add(pokemonCategory);

        _context.Add(pokemon);
        Save();
    }

    public bool UpdatePokemon(Guid ownerId, int categoryId, Pokemon pokemon)
    {
        var category = _context.Categories.FirstOrDefault(o => o.Id == categoryId);
        pokemon.User = _context.Users.FirstOrDefault(o => o.Id == ownerId);;

        var pokemonCategory = new PokemonCategory
        {
            Category = category,
            Pokemon = pokemon
        };

        _context.Update(pokemonCategory);

        _context.Update(pokemon);
        return Save();
    }

    public bool Save()
    {
        var saved = _context.SaveChanges();
        return saved > 0;
    }
    
}