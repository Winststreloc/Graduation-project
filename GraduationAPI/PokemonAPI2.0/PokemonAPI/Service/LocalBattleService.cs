using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
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

    public ICollection<Pokemon> UpdateBattle(Pokemon pokemonUser, Pokemon pokemonEnemy, Ability moveUser)
    {
        Random rnd = new Random();
        
        var enemyAbilities = _context.PokemonAbilities
            .Where(pa => pa.PokemonId == pokemonEnemy.Id)
            .Select(p => p.Ability).Take(4);

        var ability = enemyAbilities.First();

        var pokEnemyHp = GetDefence(pokemonEnemy) - GetDamage(pokemonUser, moveUser);
        var pokUserHp = GetDefence(pokemonUser) - GetDamage(pokemonEnemy, ability);
        pokemonUser.CurrentHealth = pokUserHp;
        pokemonEnemy.CurrentHealth = pokEnemyHp;
        
        var pokemons = new List<Pokemon>{pokemonUser, pokemonEnemy};
        _context.Update(pokemonUser);
        _context.Update(pokemonEnemy);
        Save();
        
        return pokemons;
    }

    private int GetDamage(Pokemon pokemon, Ability move)
    {
        return pokemon.CurrentDamage + move.Damage;
    }

    private int GetDefence(Pokemon pokemon)
    {
        return pokemon.CurrentHealth + (pokemon.CurrentDamage / 2);
    }

    public bool Save()
    {
        var saved = _context.SaveChanges();
        return saved > 0;
    }
}