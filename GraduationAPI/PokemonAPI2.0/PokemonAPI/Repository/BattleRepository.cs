using PokemonAPI.Service;
using PokemonAPI.ViewModel;
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

    public ICollection<Pokemon> UpdateBattle(BattleViewModel battle)
    {
        var pokUser = _context.Pokemons.FirstOrDefault(p => p.Id == battle.UserPokemonId);
        var pokEnemy = _context.Pokemons.FirstOrDefault(p => p.Id == battle.EnemyPokemonId);
        var ability = _context.Abilities.FirstOrDefault(a => a.Id == battle.UserAbility);
        var pokemons = _battleService.UpdateBattle(pokUser, pokEnemy, ability);
        Save();
        return pokemons;
    }

    public bool BattleEnded(ICollection<Pokemon> pokemons)
    {
        return pokemons.Any(p => p.CurrentHealth < 0);
    }

    public bool Save()
    {
        var saved = _context.SaveChanges();
        return saved > 0;
    }
}