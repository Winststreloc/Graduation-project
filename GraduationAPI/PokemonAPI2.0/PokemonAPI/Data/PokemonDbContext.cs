using Microsoft.EntityFrameworkCore;
using PokemonAPI;
using PokemonAPI.Models;
using PokemonWEB.Models;
using PokemonWEB.Models.Action;

namespace PokemonWEB.Data;

public class PokemonDbContext : DbContext
{
    public PokemonDbContext(DbContextOptions<PokemonDbContext> options) : base(options)
    {
    }

    public DbSet<Ability> Abilities { get; set; }
    public DbSet<Battle?> Battles { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Pokemon> Pokemons { get; set; }
    public DbSet<PokemonRecord> Pokedex { get; set; }
    public DbSet<PokemonAbility> PokemonAbilities { get; set; }
    public DbSet<PokemonCategory> PokemonCategories { get; set; }
    public DbSet<PokemonRecordCategory> PokemonRecordCategories { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new PokemonRecordConfiguration());
        modelBuilder.ApplyConfiguration(new UserConfiguration());
        modelBuilder.ApplyConfiguration(new PokemonAbilityConfiguration());
        modelBuilder.ApplyConfiguration(new PokemonConfiguration());
        modelBuilder.ApplyConfiguration(new PokemonCategoryConfiguration());
        modelBuilder.ApplyConfiguration(new PokRecCategoryConfiguration());
    }
}