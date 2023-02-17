using Microsoft.EntityFrameworkCore;
using PokemonAPI.Dto;
using PokemonAPI.Models;
using PokemonAPI.Models.Enums;
using PokemonWEB.Data;
using PokemonWEB.Interfaces;

namespace PokemonWEB.Repository;

public class BattleRepository : IBattleRepository
{
    private readonly PokemonDbContext _context;
    private const int MaxCountAbilities = 4;

    public BattleRepository(PokemonDbContext context)
    {
        _context = context;
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

    public async Task AddBattle(Battle battle)
    {
        _context.Battles.Add(battle);
        await _context.SaveChangesAsync();
    }
    
    public async Task<BattleInfoDto?> GetBattleInfo(Guid battleId, Guid userId)
    {
        var battle = await _context.Battles.SingleOrDefaultAsync(b => b.Id == battleId);

        var userAndEnemyPokemons = await _context.Pokemons
            .Where(p => p.Id == battle.AttackPokemon || p.Id == battle.DefendingPokemon)
            .Include(p => p.PokemonRecord)
            .ToListAsync();

        var userPokemon = userAndEnemyPokemons.FirstOrDefault(p => p.UserId == userId);
        var enemyPokemon = userAndEnemyPokemons.FirstOrDefault(p => p.UserId != userId);
        bool queue = !(userPokemon.Id != battle.AttackPokemon);


        var abilities = await _context.PokemonAbilities
            .Where(pa => pa.PokemonId == userPokemon.Id)
            .Select(p => p.Ability)
            .Take(MaxCountAbilities)
            .ToListAsync();

        return new BattleInfoDto()
        {
            UserPokemonAbilities = abilities,
            UserPokemon = userPokemon,
            EnemyPokemon = enemyPokemon,
            Queue = queue
        };
    }


    public async Task<Battle> GetValidBattle(Guid battleId)
    {
        return await _context.Battles.SingleOrDefaultAsync(b => b.Id == battleId);
    }

    public async Task UpdateBattle(Battle battle)
    {
        _context.Update(battle);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteBattle(Battle battle)
    {
        _context.Remove(battle);
        await _context.SaveChangesAsync();
    }
}