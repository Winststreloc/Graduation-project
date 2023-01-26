using PokemonAPI.Dto;
using PokemonAPI.Interfaces;
using PokemonWEB.Data;
using PokemonWEB.Models;
using PokemonWEB.Models.Action;

namespace PokemonAPI.Service;

public class BattleService : IBattleService
{
    private readonly PokemonDbContext _context;

    public BattleService(PokemonDbContext context)
    {
        _context = context;
    }

    public BattleResponceDto MovePokemon(Pokemon pokemon1, Pokemon pokemon2,  Ability ability)
    {
        var damage = GetDamage(pokemon1, ability);
        pokemon2.CurrentHealth = GetDefence(pokemon2) - damage;
        var description = ability.Description + ": " + damage;
        bool battleEnded = pokemon2.CurrentHealth <= 0;
        
        var battleResponce = new BattleResponceDto()
        {
            BattleEnded = battleEnded,
            Description = description,
            Pokemon1 = pokemon1,
            Pokemon2 = pokemon2
        };
        
        return battleResponce;
    }
    
    private int GetDamage(Pokemon pokemon, Ability move)
    {
        return pokemon.CurrentDamage + move.Damage;
    }

    private int GetDefence(Pokemon pokemon)
    {
        return pokemon.CurrentHealth + (pokemon.CurrentDamage / 2);
    }
}