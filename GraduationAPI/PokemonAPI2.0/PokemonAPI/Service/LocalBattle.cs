using PokemonAPI2._0.Models.Action;
using PokemonWEB.Data;
using PokemonWEB.Models;
using PokemonWEB.Models.Action;

namespace PokemonAPI.Service;

public class LocalBattle : ILocalBattle
{
    private readonly PokemonDbContext _context;

    public LocalBattle(PokemonDbContext context)
    {
        _context = context;
    }

    public bool UpdateBattle(Battle battle, Ability moveUser)
    {
        Pokemon pokemonUser = battle.PokemonUser;
        Pokemon pokemonEnemy = battle.PokemonEnemy;
        var enemyAbilities =
            (from a in _context.Abilities
                join pa in _context.PokemonAbilities on a.Id equals pa.AbilityId
                join p in _context.Pokemons on pa.PokemonId equals p.Id
                select new Ability()
            );
        var abilities = enemyAbilities.ToArray();
        Random rnd = new Random();
        var ability = abilities[rnd.Next(abilities.Length)];

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