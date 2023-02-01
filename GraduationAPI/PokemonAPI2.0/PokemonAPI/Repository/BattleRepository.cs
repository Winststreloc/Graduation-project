using Microsoft.EntityFrameworkCore;
using PokemonAPI.Dto;
using PokemonAPI.Interfaces;
using PokemonAPI.Models;
using PokemonAPI.Models.Enums;
using PokemonWEB.Data;
using PokemonWEB.Interfaces;
using PokemonWEB.Models;
using PokemonWEB.Models.Action;

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
        var battle = new Battle()
        {
            AttackPokemon = battleCreateDto.AttackPokemon,
            DefendingPokemon = battleCreateDto.DefendingPokemon,
            BattleEnded = false,
            Queue = Queue.FirstPokemon
        };
        _context.Battles.Add(battle);
        await _context.SaveChangesAsync();

        return battle.Id;
    }

    public async Task<Battle> CreateLocalBattle(Guid attackPokemonId)
    {
        var defendingPokemonId = await _battleService.GenerateRandomPokemon();
        var battle = new Battle()
        {
            AttackPokemon = attackPokemonId,
            DefendingPokemon = defendingPokemonId,
            BattleEnded = false,
            Queue = Queue.FirstPokemon
        };

        _context.Battles.Add(battle);
        await _context.SaveChangesAsync();

        return battle;
    }

    public async Task<BattleResponceDto> MovePokemon(BattleMoveDto battleMoveDto)
    {
        var battle = await GetValidBattle(battleMoveDto.BattleId);
        var move = await GetValidMove(battleMoveDto.AbilityId);
        var (attackPokemon, defendingPokemon) = await GetBattlingPokemons(battle);
        var battleResponceDto = _battleService.MovePokemon(attackPokemon, defendingPokemon, move);
        await ChangeQueue(battle);

        if (await _pokemonRepository.IsComputerPokemon(battle.Queue == Queue.FirstPokemon ? attackPokemon : defendingPokemon))
        {
            battleResponceDto = await MoveComputerPokemon(battle, attackPokemon, defendingPokemon, battle.Queue, battleResponceDto);
        }

        _context.Update(battle);
        _context.Update(defendingPokemon);
        await _context.SaveChangesAsync();

        return battleResponceDto;
    }

    private async Task<BattleResponceDto> MoveComputerPokemon(Battle battle, Pokemon attackPokemon, Pokemon defendingPokemon,
        Queue currentQueue, BattleResponceDto battleResponceDto)
    {
        var computerPokemonId = battle.Queue == Queue.FirstPokemon ? attackPokemon.Id : defendingPokemon.Id;
        battleResponceDto = _battleService.MovePokemon(currentQueue == Queue.FirstPokemon ? attackPokemon : defendingPokemon,
            currentQueue == Queue.FirstPokemon ? defendingPokemon : attackPokemon,
            await _battleService.GetRandomPokemonAbility(computerPokemonId));
        battle.Queue = currentQueue == Queue.FirstPokemon ? Queue.SecondPokemon : Queue.FirstPokemon;
        return battleResponceDto;
    }
    
    private async Task<Battle> GetValidBattle(Guid battleId)
    {
        var battle = await _context.Battles.SingleOrDefaultAsync(b => b.Id == battleId);
        if (battle == null || battle.BattleEnded)
        {
            throw new Exception("Battle not found or ended");
        }
        return battle;
    }
    
    private async Task<Ability> GetValidMove(int abilityId)
    {
        var move = await _context.Abilities.SingleOrDefaultAsync(a => a.Id == abilityId);
        if (move == null)
        {
            throw new ArgumentNullException("Move not found", nameof(move));
        }
        return move;
    }
    private async Task<(Pokemon, Pokemon)> GetBattlingPokemons(Battle battle)
    {
        var attackPokemonId = battle.Queue == Queue.FirstPokemon ? battle.AttackPokemon : battle.DefendingPokemon;
        var attackPokemon = await _context.Pokemons.SingleOrDefaultAsync(p => p.Id == attackPokemonId);
        var defendingPokemonId = battle.Queue == Queue.FirstPokemon ? battle.DefendingPokemon : battle.AttackPokemon;
        var defendingPokemon = await _context.Pokemons.SingleOrDefaultAsync(p => p.Id == defendingPokemonId);
        return (attackPokemon, defendingPokemon);
    }
    

    private async Task ChangeQueue(Battle battle)
    {
        battle.Queue = battle.Queue == Queue.FirstPokemon ? Queue.SecondPokemon : Queue.FirstPokemon;
        _context.Battles.Update(battle);
        await _context.SaveChangesAsync();
    }
}