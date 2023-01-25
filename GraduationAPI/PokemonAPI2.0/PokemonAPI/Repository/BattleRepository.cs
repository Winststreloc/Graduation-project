using Microsoft.EntityFrameworkCore;
using PokemonAPI.Dto;
using PokemonAPI.Interfaces;
using PokemonAPI.Models;
using PokemonAPI.Models.Enums;
using PokemonWEB.Data;
using PokemonWEB.Interfaces;

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

    public async Task<BattleResponceDto> MovePokemon(BattleMoveDto battleMoveDto)
    {
        var battle = await _context.Battles.SingleOrDefaultAsync(b => b.Id == battleMoveDto.BattleId);
        var move = await _context.Abilities.SingleOrDefaultAsync(a => a.Id == battleMoveDto.AbilityId);
        if (battle.BattleEnded)
            return new BattleResponceDto();

        var pokemon1 = await _context.Pokemons.SingleOrDefaultAsync(p => p.Id == battle.Pokemon1);
        var pokemon2 = await _context.Pokemons.SingleOrDefaultAsync(p => p.Id == battle.Pokemon2);
        var pokemon = battle.Queue == Queue.FirstPokemon ? pokemon1 : pokemon2;
        return _battleService.MovePokemon(pokemon, battle.Queue == Queue.FirstPokemon ? pokemon2 : pokemon1, move);
    }

}