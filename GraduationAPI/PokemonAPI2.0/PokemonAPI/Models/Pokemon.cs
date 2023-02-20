using PokemonAPI;
using PokemonAPI.Models;
using PokemonWEB.Data;

namespace PokemonWEB.Models;

public class Pokemon
{
    public Guid Id { get; set; }
    public int PokemonRecordId { get; set; }
    public PokemonRecord PokemonRecord { get; set; }
    public Guid UserId { get; set; }
    public User? User { get; set; }
    public Guid? BattleId { get; set; }
    public Battle? Battle { get; set; }
    public string Name { get; set; }
    public bool? Gender { get; set; }
    public int Experience { get; set; }
    public int CurrentHealth { get; set; }
    public int CurrentDamage { get; set; }
    public int CurrentDefence { get; set; }
    public int MaxDamage => CalculateMaxStat(PokemonRecord.BaseDefense);
    public int MaxHealth => CalculateMaxStat(PokemonRecord.BaseDefense);
    public int MaxDefence => CalculateMaxStat(PokemonRecord.BaseDefense);
    public int CurrentLevel => new Level().GetCurrentLevel(Experience);

    public int ExperianceToNextLevel => new Level().GetExperienceToNextLevel(Experience);
    public List<PokemonAbility> PokemonAbilities { get; set; }
    public IEnumerable<PokemonCategory>? PokemonCategories { get; set; }
    
    private int CalculateMaxStat(int baseStat)
    {
        var result = baseStat + CurrentLevel;
        return result;
    }
}