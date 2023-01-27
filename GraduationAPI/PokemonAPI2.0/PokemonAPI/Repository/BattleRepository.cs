using AutoMapper;
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

    public BattleRepository(PokemonDbContext context, IBattleService battleService)
    {
        _context = context;
        _battleService = battleService;
    }
    
    public async Task<Guid> CreateBattle(BattleCreateDto battleCreateDto)
    {
        var battle = new Battle()
        {
            Pokemon1 = battleCreateDto.Pokemon1,
            Pokemon2 = battleCreateDto.Pokemon2,
            BattleEnded = false,
            Queue = Queue.FirstPokemon
        };
        _context.Battles.Add(battle);
        await _context.SaveChangesAsync();

        return battle.Id;
    }

    public async Task<Guid> CreateLocalBattle(Guid pokemonId)
    {
        var battle = new Battle()
        {
            Pokemon1 = pokemonId,
            Pokemon2 = await _battleService.GenerateRandomPokemon(),
            BattleEnded = false,
            Queue = Queue.FirstPokemon
        };
        
        _context.Battles.Add(battle);
        await _context.SaveChangesAsync();

        return battle.Id;
    }

    public async Task<BattleResponceDto> MovePokemon(BattleMoveDto battleMoveDto)
    {
        var battle = await _context.Battles.SingleOrDefaultAsync(b => b.Id == battleMoveDto.BattleId);
        var move = await _context.Abilities.SingleOrDefaultAsync(a => a.Id == battleMoveDto.AbilityId);
        var currentQueue = battle.Queue;
        
        if (battle.BattleEnded)
        {
            throw new Exception("Battle ended");
        }


        var pokemon1 = await _context.Pokemons.SingleOrDefaultAsync(p => p.Id == battle.Pokemon1);
        var pokemon2 = await _context.Pokemons.SingleOrDefaultAsync(p => p.Id == battle.Pokemon2);
        
        var responseDto = _battleService.MovePokemon(currentQueue == Queue.FirstPokemon ? pokemon1 : pokemon2, currentQueue == Queue.FirstPokemon ? pokemon2 : pokemon1, move);

        battle.Queue = currentQueue == Queue.FirstPokemon ? Queue.SecondPokemon : Queue.FirstPokemon;
        _context.Update(battle);
        _context.Update(responseDto.Pokemon2);
        
        if (battle.BattleEnded)
        {
            _context.Remove(battle);
        }
        
        await _context.SaveChangesAsync();

        return responseDto;
    }
}