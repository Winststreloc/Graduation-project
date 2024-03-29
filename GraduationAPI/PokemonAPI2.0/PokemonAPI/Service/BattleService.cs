﻿using Microsoft.EntityFrameworkCore;
using PokemonAPI.Dto;
using PokemonAPI.Interfaces;
using PokemonAPI.Interfaces.IRepository;
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
    private readonly IBattleRepository _battleRepository;
    private readonly IAbilityRepository _abilityRepository;
    private readonly IPokemonService _pokemonService;
    private readonly ICategoryRepository _categoryRepository;
    
    private static readonly int[] RandomPokemonsIdForLocalBattle = { 1, 4, 7, 10 };
    private static readonly int[] RandomAbilityIdForLocalBattle = { 1, 2, 3 };
    private const string ComputerNickName = "ashKetchum";
    
    public BattleService(PokemonDbContext context, IPokemonRepository pokemonRepository, IBattleRepository battleRepository, IAbilityRepository abilityRepository, IPokemonService pokemonService, ICategoryRepository categoryRepository)
    {
        _context = context;
        _pokemonRepository = pokemonRepository;
        _battleRepository = battleRepository;
        _abilityRepository = abilityRepository;
        _pokemonService = pokemonService;
        _categoryRepository = categoryRepository;
    }

    public async Task<BattleResponceDto> UpdatePokemon(BattleMoveDto battleMoveDto)
    {
        var battle = await _battleRepository.GetValidBattle(battleMoveDto.BattleId);
        var move = await _abilityRepository.GetValidMove(battleMoveDto.AbilityId);
        var (attackPokemon, defendingPokemon) = await GetBattlingPokemons(battle);
        var battleResponceDto = await MovePokemon(attackPokemon, defendingPokemon, move);
        await ChangeQueue(battle);
        
        if (battle.BattleEnded)
        {
            await _battleRepository.DeleteBattle(battle);
        }
        
        return battleResponceDto;
    }

    public async Task<BattleResponceDto> MovePokemon(Pokemon? attackPokemon, Pokemon? defendingPokemon,  Ability? ability)
    {
        var damage = GetDamage(attackPokemon, ability);
        defendingPokemon!.CurrentHealth -= damage;
        bool battleEnded = defendingPokemon.CurrentHealth <= 0;
        
        var battleResponce = new BattleResponceDto()
        {
            BattleEnded = battleEnded,
            NameAbilityFirstPokemon = ability.Name,
            DescriptionFirstPokemon = ability.Description,
            DamageFirstPokemon = damage,
            AtackPokemon = attackPokemon,
            DefendingPokemon = defendingPokemon
        };

        if (await _pokemonRepository.IsComputerPokemon(defendingPokemon))
        {
            ability = GetRandomAbility();
            damage = GetDamage(defendingPokemon, ability);
            attackPokemon.CurrentHealth -= damage;
            battleResponce.BattleEnded = defendingPokemon.CurrentHealth <= 0;
            battleResponce.AtackPokemon = attackPokemon;
            battleResponce.DamageSecondPokemon = damage;
            battleResponce.DescriptionSecondPokemon = ability.Description;
            battleResponce.NameAbilitySecondPokemon = ability.Name;
            _context.Update(attackPokemon);
        }

        _context.Update(defendingPokemon);
        await _context.SaveChangesAsync();

        return battleResponce;
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

        var pokemon = await _pokemonService.CreatePokemon(pokeRecord, computerUser);
        var pokemonAbility = _abilityRepository.CreatePokemonAbility(pokemon, rndAbility);
        var pokemonCategory = _categoryRepository.CreatePokemonCategory(pokemon, rndCategory);

        _context.Add(pokemonAbility);
        _context.Add(pokemonCategory);
        _context.Add(pokemon);
        _context.SaveChanges();

        return pokemon.Id;
    }
    
    public async Task<Battle?> CreateLocalBattle(Guid attackPokemonId)
    {
        var defendingPokemonId = await GenerateRandomPokemon();
        var battle = new Battle()
        {
            AttackPokemon = attackPokemonId,
            DefendingPokemon = defendingPokemonId,
            BattleEnded = false,
            Queue = Queue.FirstPokemon
        };
        await _battleRepository.AddBattle(battle);
        return battle;
    }
    
    private async Task<(Pokemon, Pokemon)> GetBattlingPokemons(Battle battle)
    {
        var attackPokemonId = battle.Queue == Queue.FirstPokemon ? battle.AttackPokemon : battle.DefendingPokemon;
        var attackPokemon = await _context.Pokemons
            .Include(p => p.PokemonRecord)
            .SingleOrDefaultAsync(p => p.Id == attackPokemonId);
        var defendingPokemonId = battle.Queue == Queue.FirstPokemon ? battle.DefendingPokemon : battle.AttackPokemon;
        var defendingPokemon = await _context.Pokemons
            .Include(p => p.PokemonRecord)
            .SingleOrDefaultAsync(p => p.Id == defendingPokemonId);
        return (attackPokemon, defendingPokemon);
    }
    
    private async Task ChangeQueue(Battle battle)
    {
        var pokemon = _context.Pokemons.SingleOrDefault(p => p.Id == battle.DefendingPokemon);
        Queue queue = Queue.FirstPokemon;
        if (!await _pokemonRepository.IsComputerPokemon(pokemon))
        {
             queue = battle.Queue == Queue.FirstPokemon ? Queue.SecondPokemon : Queue.FirstPokemon;
             battle.Queue = queue;
        }
        await _battleRepository.UpdateBattle(battle);
    }
    
    private int GetRandomPokemonId()
    {
        Random rnd = new Random();
        return RandomPokemonsIdForLocalBattle[rnd.Next(RandomPokemonsIdForLocalBattle.Length)];
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