using System.ComponentModel.DataAnnotations;
using PokemonAPI;
using PokemonWEB.Data;

namespace PokemonWEB.Models;

public class Pokemon
{
    private PokemonDbContext _context;
    public Guid Id { get; set; }
    public int PokedexId { get; set; }
    public string Name { get; set; }
    public int Weight { get; set; }
    public int Height { get; set; }
    public bool Gender { get; set; }
    public int Experience { get; set; }
    [Range(0, 100)] public int Level => GetLevel();
    public double Damage => GetDamage();
    public double HP => GetHP();
    public double Defence => GetDefence();


    public ICollection<PokemonAbility> PokemonAbilities { get; set; }
    public ICollection<PokemonOwner> PokemonOwners { get; set; }
    public ICollection<PokemonCategory> PokemonCategories { get; set; }

    private int GetLevel()
    {
        int currentLevel = 0;
        int remainingXP = Experience;

        while (true)
        {
            int requiredForNextLevel;
            if (currentLevel <= 16)
            {
                requiredForNextLevel = (2 * currentLevel) + 7;
            }
            else if (currentLevel >= 17 && currentLevel <= 31)
            {
                requiredForNextLevel = (5 * currentLevel) - 38;
            }
            else
            {
                requiredForNextLevel = (9 * currentLevel) - 158;
            }

            if (remainingXP >= requiredForNextLevel)
            {
                remainingXP -= requiredForNextLevel;
                currentLevel++;
            }
            else break;
        }

        return currentLevel;
    }

    private int GetDamage()
    {
        var pokedex = _context.Pokedex.FirstOrDefault(p => p.PokedexId == PokedexId);
        return pokedex.BaseDamage * (1 + Level / 100);
    }

    private int GetHP()
    {
        var pokedex = _context.Pokedex.FirstOrDefault(p => p.PokedexId == PokedexId);
        return pokedex.BaseHP * (1 + Level / 100);
    }

    private int GetDefence()
    {
        var pokedex = _context.Pokedex.FirstOrDefault(p => p.PokedexId == PokedexId);
        return pokedex.BaseHP * (1 + Level / 100);
    }
}