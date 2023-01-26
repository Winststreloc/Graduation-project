
using PokemonAPI;



namespace PokemonWEB.Models;

public class Pokemon
{
    public Guid Id { get; set; }
    public int PokemonRecordId { get; set; }
    public PokemonRecord? PokemonRecord { get; set; }
    public string Name { get; set; }
    public bool Gender { get; set; }
    public int Experience { get; set; }
    public int CurrentHealth { get; set; }
    public int CurrentDamage { get; set; }
    public int CurrentDefence { get; set; }
    public int Level => GetLevel();
    // public int MaxHealth => GetHP();
    // public int MaxDamage => GetDamage();
    // public int MaxDefence => GetDefence();


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

    // public int GetDamage()
    // {
    //     var pokedex = _context.Pokedex.FirstOrDefault(p => p.PokedexId == PokedexId);
    //     return pokedex.BaseDamage * (1 + Level / 100);
    // }
    //
    // public int GetHP()
    // {
    //     var pokedex = _context.Pokedex.SingleOrDefault(p => p.PokedexId == PokedexId);
    //     return pokedex.BaseHP * (1 + Level / 100);
    // }
    //
    // public int GetDefence()
    // {
    //     var pokedex = _context.Pokedex.FirstOrDefault(p => p.PokedexId == PokedexId);
    //     return pokedex.BaseHP * (1 + Level / 100);
    // }
    
}