using Microsoft.EntityFrameworkCore;
using PokemonAPI.Dto;
using PokemonAPI.Interfaces;
using PokemonAPI.Models;
using PokemonAPI.Models.Enums;
using PokemonWEB.Data;
using PokemonWEB.Interfaces;
using PokemonWEB.Models;

namespace PokemonWEB.Repository;

public class BattleRepository : IBattleRepository
{
    private readonly PokemonDbContext _context;
    private readonly IBattleService _battleService;
    private readonly IPokemonRepository _pokemonRepository;

    public BattleRepository(PokemonDbContext context, IBattleService battleService,
        IPokemonRepository pokemonRepository)
    {
        _context = context;
        _battleService = battleService;
        _pokemonRepository = pokemonRepository;
    }

    public async Task<Guid> CreateBattle(BattleCreateDto battleCreateDto)
    {
        var attackPokemon = await _context.Pokemons.SingleOrDefaultAsync(p => p.Id ==battleCreateDto.AttackPokemon);
        var defendingPokemon = await _context.Pokemons.SingleOrDefaultAsync(p => p.Id ==battleCreateDto.DefendingPokemon);
        var battle = new Battle()
        {
            Pokemons = new List<Pokemon>()
            {
                attackPokemon!,
                defendingPokemon!
            },
            BattleEnded = false,
            Queue = Queue.FirstPokemon
        };
        _context.Battles.Add(battle);
        await _context.SaveChangesAsync();

        return battle.Id;
    }

    public async Task<Battle> CreateLocalBattle(Guid pokemonId)
    {
        var attackPokemon = await _context.Pokemons.SingleOrDefaultAsync(p => p.Id == pokemonId);
        var battle = new Battle()
        {
            Pokemons = new List<Pokemon>()
            {
                attackPokemon!,
                await _battleService.GenerateRandomPokemon()
            },
            BattleEnded = false,
            Queue = Queue.FirstPokemon
        };

        _context.Battles.Add(battle);
        await _context.SaveChangesAsync();

        return battle;
    }

    public async Task<BattleResponceDto> MovePokemon(BattleMoveDto battleMoveDto)
    {
        var battle = await _context.Battles.SingleOrDefaultAsync(b => b.Id == battleMoveDto.BattleId);
        var battleQueue = battle.Queue;
        if (battle == null || battle.BattleEnded)
        {
            throw new Exception("Battle not found or ended");
        }
        
        var move = await _context.Abilities.SingleOrDefaultAsync(a => a.Id == battleMoveDto.AbilityId);
        if (move == null)
        {
            throw new ArgumentNullException("Move not found", nameof(move));
        }

        var attackPokemon = battle.Queue == Queue.FirstPokemon ? battle.Pokemons.First() : battle.Pokemons.Last();
        var defendingPokemon = battle.Queue == Queue.FirstPokemon ? battle.Pokemons.Last() : battle.Pokemons.First();

        var battleResponceDto = _battleService.MovePokemon(attackPokemon, defendingPokemon, move);
        
        await ChangeQueue(battle);
        

        if (await _pokemonRepository.IsComputerPokemon(battle.Queue == Queue.FirstPokemon ? battle.Pokemons.First() : battle.Pokemons.Last()))
        {
            battleResponceDto = await MoveComputerPokemon(battle, attackPokemon, defendingPokemon, battleQueue, battleResponceDto);
        }

        _context.Update(battle);
        _context.Update(defendingPokemon);

        // if (battle.BattleEnded) //TODO 
        // {
        //     _context.Remove(battle);
        // }

        await _context.SaveChangesAsync();

        return battleResponceDto;
    }

    private async Task<BattleResponceDto> MoveComputerPokemon(Battle battle, Pokemon pokemon1, Pokemon pokemon2,
        Queue currentQueue, BattleResponceDto battleResponceDto)
    {
        var computerPokemonId = battle.Queue == Queue.FirstPokemon ? pokemon1.Id : pokemon2.Id;
        battleResponceDto = _battleService.MovePokemon(currentQueue == Queue.FirstPokemon ? pokemon1 : pokemon2,
            currentQueue == Queue.FirstPokemon ? pokemon2 : pokemon1,
            await _battleService.GetRandomPokemonAbility(computerPokemonId));
        battle.Queue = currentQueue == Queue.FirstPokemon ? Queue.SecondPokemon : Queue.FirstPokemon;
        return battleResponceDto;
    }

    private async Task ChangeQueue(Battle battle)
    {
        battle.Queue = battle.Queue == Queue.FirstPokemon ? Queue.SecondPokemon : Queue.FirstPokemon;
        _context.Battles.Update(battle);
        await _context.SaveChangesAsync();
    }
}