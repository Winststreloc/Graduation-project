using Microsoft.EntityFrameworkCore;
using PokemonWEB.Data;
using PokemonWEB.Interfaces;
using PokemonWEB.Models;
using PokemonWEB.Models.Action;

namespace PokemonWEB.Repository;

public class PokemonRepository : IPokemonRepository
{
    private readonly PokemonDbContext _context;
    
    public PokemonRepository(PokemonDbContext context)
    {
        _context = context;
    }

    public Pokemon GetPokemon(Guid Id)
    {
        return _context.Pokemons.FirstOrDefault(p => p.Id == Id);
    }

    public ICollection<Pokemon> GetPokemons(int count)
    {
        return _context.Pokemons.Take(count).OrderBy(p => p.PokedexId).ToList();
    }

    public IQueryable<Ability> GetPokemonAbilities(Guid pokemonId)
    {
        var pokemon = _context.Pokemons.SingleOrDefault(p => p.Id == pokemonId);
        var abilities = _context.PokemonAbilities
            .Where(pa => pa.PokemonId == pokemon.Id)
            .Select(p => p.Ability).Take(4);
        return abilities;
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

    public void CreatePokemon(Guid ownerId, Guid categoryId, Pokemon pokemon)
    {
        var pokemonOwnerEntity = _context.Owners.FirstOrDefault(o => o.Id == ownerId);
        var category = _context.Categories.FirstOrDefault(o => o.Id == categoryId);

        var pokemonOwner = new PokemonOwner
        {
            Owner = pokemonOwnerEntity,
            Pokemon = pokemon
        };

        _context.Add(pokemonOwner);

        var pokemonCategory = new PokemonCategory
        {
            Category = category,
            Pokemon = pokemon
        };

        _context.Add(pokemonCategory);

        _context.Add(pokemon);
        Save();
    }

    public bool UpdatePokemon(Guid ownerId, Guid categoryId, Pokemon pokemon)
    {
        var pokemonOwnerEntity = _context.Owners.FirstOrDefault(o => o.Id == ownerId);
        var category = _context.Categories.FirstOrDefault(o => o.Id == categoryId);

        var pokemonOwner = new PokemonOwner
        {
            Owner = pokemonOwnerEntity,
            Pokemon = pokemon
        };

        _context.Update(pokemonOwner);

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