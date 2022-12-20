using PokemonWEB.Data;
using PokemonWEB.Interfaces;
using PokemonWEB.Models.Action;
using PokemonWEB.Models.Battle;

namespace PokemonWEB.Models;

public class PokemonBattleRepository : IPokemonBattleRepository
{
    private readonly PokemonDbContext _context;

    public PokemonBattleRepository(PokemonDbContext context)
    {
        _context = context;
    }

    public void LocalBattle(Pokemon pokemonUser, Pokemon pokemonEnemy)
    {
        throw new NotImplementedException();
    }

    public bool UpdateBattle(PokemonBattle battle, Moves moveUser, Moves moveEnemy)
    {
        Pokemon pokemonUser = battle.pokemonUser;
        Pokemon pokemonEnemy = battle.pokemonEnemy;
        double pokEnemyHp = GetDefence(pokemonEnemy) - GetDamage(pokemonUser, moveUser);
        double pokUserHp = GetDefence(pokemonUser) - GetDamage(pokemonEnemy, moveEnemy);

        _context.Update(pokemonUser);
        
        return Save();
    }

    public bool BattleEnded(PokemonBattle battle) //TODO
    {
        return Save();
    }

    public void PrintBattleStatus(PokemonBattleRepository battleRepository, Pokemon pokemonUser, Pokemon pokemonEnemy)
    {
        throw new NotImplementedException();
    }

    private double GetDamage(Pokemon pokemon, Moves move)
    {
        return pokemon.Damage + move.Damage;
    }

    private double GetDefence(Pokemon pokemon)
    {
        return pokemon.HP + (pokemon.Defence / 2);
    }
    
    public bool Save()
    {
        var saved = _context.SaveChanges();
        return saved > 0;
    }
}