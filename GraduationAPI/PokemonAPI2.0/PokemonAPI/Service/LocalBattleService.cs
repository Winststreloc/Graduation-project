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
            .Select(p => p.Ability)
            .Take(4);
        
        pokemonUser.CurrentHealth = GetDefence(pokemonUser) - GetDamage(pokemonEnemy, enemyAbilities.ElementAt(rnd.Next(enemyAbilities.Count())));
        pokemonEnemy.CurrentHealth = GetDefence(pokemonEnemy) - GetDamage(pokemonUser, moveUser);
        
        _context.Update(pokemonUser);
        _context.Update(pokemonEnemy);
        Save();
        
        return new List<Pokemon>{pokemonUser, pokemonEnemy};
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