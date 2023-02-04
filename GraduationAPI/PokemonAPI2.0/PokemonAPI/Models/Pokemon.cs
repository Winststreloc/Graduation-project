using PokemonAPI;
using PokemonAPI.Models;
using PokemonWEB.Data;

namespace PokemonWEB.Models;

public class Pokemon
{
    private readonly PokemonDbContext _context;

    public Pokemon(PokemonDbContext context)
    {
        _context = context;
    }

    public Pokemon()
    {
        
    }

    public Guid Id { get; set; }
    public int PokemonRecordId { get; set; }
    public PokemonRecord PokemonRecord => _context.Pokedex.SingleOrDefault(p => p.Id == PokemonRecordId) ?? throw new InvalidOperationException();
    public Guid UserId { get; set; }
    public User? User { get; set; }
    public Guid? BattleId { get; set; }
    public Battle? Battle { get; set; }
    public string Name { get; set; }
    public bool? Gender { get; set; }
    public int Experience { get; set; }
    public int CurrentHealth { get; set; }
    public int MaxHealth => CalculateMaxStat(PokemonRecord.BaseDefense);
    public int CurrentDamage { get; set; }
    public int MaxDamage => CalculateMaxStat(PokemonRecord.BaseDefense);
    public int CurrentDefence { get; set; }
    public int MaxDefence => CalculateMaxStat(PokemonRecord.BaseDefense);
    public int Level => CalculateLevel();
    public List<PokemonAbility> PokemonAbilities { get; set; }
    public IEnumerable<PokemonCategory>? PokemonCategories { get; set; } //TODO
    
    private int CalculateMaxStat(int baseStat)
    {
        var result = (double)baseStat * 2 * ((double)Level / 100.0) + 10.0 + (double)Level;
        return (int)result;
    }
    private int CalculateLevel()
    {
        int currentLevel = 0;
        int remainingXP = Experience;

        while (true)
        {
            int requiredForNextLevel = currentLevel <= 16 ? (2 * currentLevel) + 7 
                : currentLevel >= 17 && currentLevel <= 31 ? (5 * currentLevel) - 38 
                : (9 * currentLevel) - 158;

            if (remainingXP >= requiredForNextLevel)
            {
                remainingXP -= requiredForNextLevel;
                currentLevel++;
            }
            else break;
        }

        return currentLevel;
    }
}