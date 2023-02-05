using Microsoft.EntityFrameworkCore;
using PokemonAPI.Dto;
using PokemonAPI.Interfaces;
using PokemonAPI.Models;
using PokemonAPI.Models.Enums;
using PokemonWEB.Data;
using PokemonWEB.Interfaces;
using PokemonWEB.Models;
using PokemonWEB.Models.Action;

namespace PokemonAPI.Service;

public class BattleService : IBattleService
{
    private readonly PokemonDbContext _context;
    private readonly IPokemonRepository _pokemonRepository;
    private readonly IPokemonService _pokemonService;
    
    private static readonly int[] _randomPokemonsIdForLocalBattle = { 1, 4, 7, 10 };
    private static readonly int[] _randomAbilityIdForLocalBattle = { 1, 2, 3 };
    private const int MaxExperianceForLocalPokemons = 1001;
    private const int MinExperianceForLocalPokemons = 100;
    private const string ComputerNickName = "ashKetchum";
    
    public BattleService(PokemonDbContext context, IPokemonRepository pokemonRepository, IPokemonService pokemonService)
    {
        _context = context;
        _pokemonRepository = pokemonRepository;
        _pokemonService = pokemonService;
    }

    public async Task<(BattleResponceDto, Battle)> MovePokemon(Pokemon? attackPokemon, Pokemon? defendingPokemon,  Ability? ability, Battle battle)
    {
        var damage = GetDamage(attackPokemon, ability);
        defendingPokemon!.CurrentHealth -= damage;
        bool battleEnded = defendingPokemon.CurrentHealth <= 0;
        
        var battleResponce = new BattleResponceDto()
        {
            BattleEnded = battleEnded,
            DescriptionFirstPokemon = ability.Description,
            DamageFirstPokemon = damage,
            AtackPokemon = attackPokemon,
            DefendingPokemon = defendingPokemon
        };
        ChangeQueue(battle);
        
        if (await _pokemonRepository.IsComputerPokemon(defendingPokemon) && !battleEnded)
        {
            damage = GetDamage(defendingPokemon, GetRandomAbility());
            attackPokemon.CurrentHealth -= damage;
            battleResponce.BattleEnded = defendingPokemon.CurrentHealth <= 0;
            battleResponce.AtackPokemon = attackPokemon;
            battleResponce.DamageSecondPokemon = damage;
            _context.Update(attackPokemon);
            ChangeQueue(battle);
        }

        _context.Update(defendingPokemon);

        return (battleResponce, battle);
    }
    public async Task<Ability?> GetRandomPokemonAbility(Guid pokemonId)
    {
        Random rnd = new Random();
        var existAbilities = await _context.PokemonAbilities
            .Where(pa => pa.PokemonId == pokemonId)
            .Select(p => p.Ability).ToListAsync();
        var result = existAbilities.ElementAtOrDefault(rnd.Next(existAbilities.Count));
        return result;
    }

    public async Task<Guid> GenerateRandomPokemon()
    {
        var randomId = GetRandomPokemonId();
        var pokeRecord = await _context.Pokedex.SingleOrDefaultAsync(p => p.Id == randomId);
        var rndAbility = GetRandomAbility();
        var rndCategory = GetRandomCategory();
        var computerUser =  await _context.Users.SingleOrDefaultAsync(u => u.NickName == ComputerNickName);

        var pokemon = await CreatePokemon(pokeRecord, computerUser);
        var pokemonAbility = CreatePokemonAbility(pokemon, rndAbility);
        var pokemonCategory = CreatePokemonCategory(pokemon, rndCategory);

        _context.Add(pokemonAbility);
        _context.Add(pokemonCategory);
        _context.Add(pokemon);
        _context.SaveChanges();
        
        //_pokemonService.HealingPokemon(pokemon);
        // await _context.SaveChangesAsync();
        
        return pokemon.Id;
    }
    
    private Queue ChangeQueue(Battle battle)
    {
        return battle.Queue == Queue.FirstPokemon ? Queue.SecondPokemon : Queue.FirstPokemon;
    }

    private PokemonCategory CreatePokemonCategory(Pokemon pokemon, Category rndCategory)
    {
        var pokemonCategory = new PokemonCategory()
        {
            Category = rndCategory,
            Pokemon = pokemon
        };
        return pokemonCategory;
    }

    private PokemonAbility CreatePokemonAbility(Pokemon pokemon, Ability rndAbility)
    {
        var pokemonAbility = new PokemonAbility()
        {
            Ability = rndAbility,
            Pokemon = pokemon
        };
        return pokemonAbility;
    }

    private async Task<Pokemon> CreatePokemon(PokemonRecord pokeRecord, User computerUser)
    {
        Random rnd = new Random();
        var pokemon = new Pokemon()
        {
            Name = pokeRecord.Name,
            PokemonRecordId = pokeRecord.Id,
            CurrentDamage = pokeRecord.BaseDamage,
            CurrentDefence = pokeRecord.BaseDefense,
            CurrentHealth = pokeRecord.BaseHP,
            Experience = rnd.Next(MinExperianceForLocalPokemons, MaxExperianceForLocalPokemons),
            Gender = true,
            User = computerUser,
            UserId = computerUser.Id
        };
        return pokemon;
    }

    private int GetRandomPokemonId()
    {
        Random rnd = new Random();
        return _randomPokemonsIdForLocalBattle[rnd.Next(_randomPokemonsIdForLocalBattle.Length)];
    }

    private Ability GetRandomAbility()
    {
        Random rnd = new Random();
        var abilities = _context.PokemonAbilities
            .Where(pa => pa.AbilityId == 1 || pa.AbilityId == 2)
            .Select(pa => pa.Ability)
            .ToList();
        return abilities.ElementAtOrDefault(rnd.Next(abilities.Count));
    }

    private Category GetRandomCategory()
    {
        Random rnd = new Random();
        var categories = _context.PokemonCategories
            .Where(c => c.CategoryId == 1 || c.CategoryId == 2)
            .Select(pc => pc.Category)
            .ToList();
        return categories.ElementAtOrDefault(rnd.Next(categories.Count));
    }

    private int GetDamage(Pokemon? pokemon, Ability? move)
    {
        var damage = (pokemon.CurrentDamage) + move.Damage - pokemon.CurrentDefence;
        if (damage < 0)
        {
            damage = 1;
        }

        return damage;
    }
}