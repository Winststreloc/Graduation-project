using Microsoft.EntityFrameworkCore;
using PokemonAPI2._0.Models.Action;
using PokemonWEB.Data;
using PokemonWEB.Models;
using PokemonWEB.Models.Action;

namespace PokemonAPI.Service;

public class LocalBattleService : ILocalBattleService
{
    private readonly PokemonDbContext _context;

    public LocalBattleService(PokemonDbContext context)
    {
        _context = context;
    }

    public bool UpdateBattle(Battle battle, Ability moveUser)
    {
        Random rnd = new Random();
        var pokemonUser = battle.PokemonUser;
        var pokemonEnemy = battle.PokemonEnemy;
        var enemyAbilities = _context.Abilities.Select(a => a.PokemonAbilities
            .Where(pa => pa.PokemonId == pokemonEnemy.Id)).ToArray();


        var ability = enemyAbilities;

        var pokEnemyHp = GetDefence(pokemonEnemy) - GetDamage(pokemonUser, moveUser);
        double pokUserHp = GetDefence(pokemonUser) - GetDamage(pokemonEnemy, ability);
        
        _context.Update(pokemonUser);

        return Save();
    }

    // public bool BattleEnded(LocalBattle battle) //TODO
    // {
    //     return Save();
    // }

    // public void PrintBattleStatus(PokemonBattleRepository battleRepository, Pokemon pokemonUser, Pokemon pokemonEnemy)
    // {
    //     throw new NotImplementedException();
    // }

    private double GetDamage(Pokemon pokemon, Ability move)
    {
        return pokemon.CurrentDamage + move.Damage;
    }

    private double GetDefence(Pokemon pokemon)
    {
        return pokemon.CurrentHealth + (pokemon.CurrentDamage / 2);
    }

    public bool Save()
    {
        var saved = _context.SaveChanges();
        return saved > 0;
    }
}