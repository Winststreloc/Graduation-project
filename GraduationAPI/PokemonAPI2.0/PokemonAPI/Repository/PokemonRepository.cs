using Microsoft.EntityFrameworkCore;
using PokemonAPI.Dto;
using PokemonAPI.Helpers;
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
    private const string ComputerNickName = "ashKetchum";
    private const int maxCountAbilities = 4;

    public PokemonRepository(PokemonDbContext context, IPokemonService pokemonService)
    {
        _context = context;
        _pokemonService = pokemonService;
    }

    public async Task<Pokemon> GetPokemon(Guid Id)
    {
        return await _context.Pokemons.FirstOrDefaultAsync(p => p.Id == Id);
    }

    public ICollection<Pokemon> GetPokemons(int count)
    {
        return _context.Pokemons.Take(count).OrderBy(p => p.PokemonRecordId).ToList();
    }

    public ICollection<Ability> GetPokemonAbilities(Guid pokemonId)
    {
        var pokemon = _context.Pokemons.SingleOrDefault(p => p.Id == pokemonId);
        var abilities = _context.PokemonAbilities
            .Where(pa => pa.PokemonId == pokemon.Id)
            .Select(p => p.Ability)
            .Take(maxCountAbilities)
            .ToList();
        return abilities;
    }

    public async Task<ICollection<Pokemon>> GetUserPokemons(Guid userId)
    {
        return await _context.Pokemons
            .Where(p => p.UserId == userId)
            .ToListAsync();
    }

    public async Task<PokemonAbilityCategoryDto> GetPokemonAbilityCategory(Guid pokemonId)
    {
        var pokemon = await _context.Pokemons.SingleOrDefaultAsync(p => p.Id == pokemonId);

        if (pokemon == null)
        {
            return null;
        }

        var abilities = await _context.PokemonAbilities
            .Where(pa => pa.PokemonId == pokemonId)
            .Select(p => p.Ability)
            .Take(maxCountAbilities)
            .ToListAsync();

        var categories = await _context.PokemonCategories
            .Where(pa => pa.PokemonId == pokemonId)
            .Select(p => p.Category)
            .ToListAsync();

        return new PokemonAbilityCategoryDto()
        {
            Abilities = abilities,
            Categories = categories,
            Pokemon = pokemon
        };
    }


    public async Task<int> HealingUserPokemons(Guid userId)
    {
        var pokemons = await GetUserPokemons(userId);
        return await _pokemonService.HealingPokemons(pokemons);
    }

    public async Task<int> HealingPokemon(Guid pokemonId)
    {
        var pokemon = await _context.Pokemons.SingleOrDefaultAsync(p => p.Id == pokemonId);
        return _pokemonService.HealingPokemon(pokemon);
    }


    public async Task<bool> IsComputerPokemon(Pokemon? pokemon)
    {
        var computer = await _context.Users.SingleOrDefaultAsync(u => u.NickName == ComputerNickName);
        var computerPokemons = await _context.Pokemons.Where(p => p.UserId == computer.Id).ToListAsync();
        return computerPokemons.Any(p => p == pokemon);
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

    public async Task<bool> CreatePokemon(Guid userId, int categoryId, Pokemon pokemon)
    {
        var pokemonOwnerEntity = await _context.Users.SingleOrDefaultAsync(o => o.Id == userId);
        var categoryEntity = await _context.Categories.SingleOrDefaultAsync(o => o.Id == categoryId);
        var pokemonCategory = new PokemonCategory
        {
            Category = categoryEntity,
            Pokemon = pokemon
        };

        pokemon.User = pokemonOwnerEntity;

        await _context.AddAsync(pokemonCategory);
        await _context.AddAsync(pokemon);

        return await _context.SaveChangesAsync() > 0;
    }


    public bool UpdatePokemon(Guid ownerId, int categoryId, Pokemon pokemon)
    {
        var category = _context.Categories.FirstOrDefault(o => o.Id == categoryId);
        pokemon.User = _context.Users.FirstOrDefault(o => o.Id == ownerId);
        ;

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

    public async Task<int> UpdateAllPokemons()
    {
        var pokemons = await _context.Pokemons.Select(p => p).ToListAsync();
        var result = await _pokemonService.HealingPokemons(pokemons);
        return result;
    }
}