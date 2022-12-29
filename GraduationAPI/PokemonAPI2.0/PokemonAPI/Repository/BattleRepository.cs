using PokemonAPI.Service;
using PokemonAPI2._0.Models.Action;
using PokemonWEB.Data;
using PokemonWEB.Interfaces;
using PokemonWEB.Models.Action;

namespace PokemonWEB.Repository;

public class BattleRepository : IBattleRepository
{
    private readonly PokemonDbContext _context;
    private readonly ILocalBattle _battle;

    public BattleRepository(PokemonDbContext context, LocalBattle battle)
    {
        _context = context;
        _battle = battle;
    }
    public Battle GetBattle(Guid Id)
    {
        throw new NotImplementedException();
    }

    public void CreateBattle(Guid pokemonId, int pokedexIdEnemy)
    {
        Battle battle = new Battle()
        {
            Id = new Guid(),
            PokemonEnemy = _context.Pokemons.FirstOrDefault(p => p.PokedexId == pokedexIdEnemy),
            PokemonUser = _context.Pokemons.FirstOrDefault(p => p.Id == pokemonId)
        };
        
        _context.Battles.Add(battle);
    }

    public bool UpdateBattle(Guid battleId, Ability ability)
    {
        var battle = _context.Battles.FirstOrDefault(b => b.Id == battleId);
        _battle.UpdateBattle(battle, ability);
        return Save();
    }

    public bool DeleteBattle(Guid battleId)
    {
        var battle = _context.Battles.FirstOrDefault(b => b.Id == battleId);
        _context.Battles.Remove(battle);
        return Save();
    }

    public bool BattleExists(Guid id)
    {
        return _context.Battles.Any(b => b.Id == id);
    }

    public bool Save()
    {
        var saved = _context.SaveChanges();
        return saved > 0;
    }
}