using PokemonAPI.Service;
using PokemonAPI2._0.Models.Action;
using PokemonWEB.Data;
using PokemonWEB.Interfaces;
using PokemonWEB.Models;

namespace PokemonWEB.Repository;

public class BattleRepository : IBattleRepository
{
    private readonly PokemonDbContext _context;
    private readonly ILocalBattleService _battleService;

    public BattleRepository(PokemonDbContext context, ILocalBattleService battleService)
    {
        _context = context;
        _battleService = battleService;
    }

    public ICollection<Pokemon> UpdateBattle(Battle battle, Guid abilityId)
    {
        var pokUser = _context.Pokemons.FirstOrDefault(p => p.Id == battle.PokemonUserId);
        var pokEnemy = _context.Pokemons.FirstOrDefault(p => p.Id == battle.PokemonEnemyId);
        var ability = _context.Abilities.FirstOrDefault(a => a.Id == abilityId);
        var pokemons = _battleService.UpdateBattle(pokUser, pokEnemy, ability);
        Save();
        return pokemons;
    }

    public bool Save()
    {
        var saved = _context.SaveChanges();
        return saved > 0;
    }
}