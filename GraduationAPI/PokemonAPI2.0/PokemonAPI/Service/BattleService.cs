using Microsoft.EntityFrameworkCore;
using PokemonAPI.Dto;
using PokemonAPI.Interfaces;
using PokemonWEB.Data;
using PokemonWEB.Models;
using PokemonWEB.Models.Action;

namespace PokemonAPI.Service;

public class BattleService : IBattleService
{
    private readonly PokemonDbContext _context;
    private static readonly int[] _randomPokemonsIdForLocalBattle = { 1, 2, 3 };
    private static readonly int[] _randomAbilityIdForLocalBattle = { 1, 2, 3 };
    private const string ComputerNickName = "ashKetchum";
    public BattleService(PokemonDbContext context)
    {
        _context = context;
    }

    public BattleResponceDto MovePokemon(Pokemon? pokemon1, Pokemon? pokemon2,  Ability ability)
    {
        var damage = GetDamage(pokemon1, ability);
        pokemon2.CurrentHealth = GetDefence(pokemon2) - damage;
        var description = ability.Description + ": " + damage;
        bool battleEnded = pokemon2.CurrentHealth <= 0;
        
        var battleResponce = new BattleResponceDto()
        {
            BattleEnded = battleEnded,
            Description = description,
            AtackPokemon = pokemon1,
            DefendingPokemon = pokemon2
        };
        
        
        return battleResponce;
    }
    
    public async Task<Pokemon> GenerateRandomPokemon()
    {
        Random rnd = new Random();
        var randomId = _randomPokemonsIdForLocalBattle[rnd.Next(_randomPokemonsIdForLocalBattle.Length - 1)];
        var pokeRecord = await _context.Pokedex.SingleOrDefaultAsync(p =>
            p.Id == randomId);
        var abilities = _context.PokemonAbilities
            .Where(pa => pa.AbilityId == 1 && pa.AbilityId == 2)
            .ToList();
        var categories = _context.PokemonCategories
            .Where(c => c.CategoryId == 1 && c.CategoryId == 2)
            .ToList();

        var pokemon = new Pokemon()
        {
            Name = pokeRecord.Name,
            PokemonRecordId = pokeRecord.Id,
            CurrentDamage = pokeRecord.BaseDamage,
            CurrentDefence = pokeRecord.BaseDefense,
            CurrentHealth = pokeRecord.BaseHP,
            PokemonAbilities = abilities,
            Experience = 0,
            Gender = default,
            PokemonCategories = categories
        };
        
        _context.Pokemons.Add(pokemon);
        await _context.SaveChangesAsync();
        
        return pokemon;
    }

    public async Task<Ability> GetRandomPokemonAbility(Guid pokemonId)
    {
        Random rnd = new Random();
        var existAbilities = await _context.PokemonAbilities
            .Where(pa => pa.PokemonId == pokemonId)
            .Select(p => p.Ability).ToArrayAsync();
        return existAbilities.ElementAt(rnd.Next(existAbilities.Length));
    }

    private int GetDamage(Pokemon? pokemon, Ability move)
    {
        return pokemon.CurrentDamage + move.Damage;
    }

    private int GetDefence(Pokemon? pokemon)
    {
        return pokemon.CurrentHealth + (pokemon.CurrentDamage / 2);
    }
}