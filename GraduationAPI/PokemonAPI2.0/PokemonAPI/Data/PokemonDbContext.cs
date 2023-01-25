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
    public DbSet<Battle> Battles { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Pokemon> Pokemons { get; set; }
    public DbSet<PokemonRecord> Pokedex { get; set; }
    public DbSet<PokemonAbility> PokemonAbilities { get; set; }
    public DbSet<PokemonCategory> PokemonCategories { get; set; }
    public DbSet<PokemonOwner> PokemonOwners { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<PokemonRecord>()
            .HasKey(p => p.PokedexId);
        modelBuilder.Entity<PokemonRecord>()
            .HasMany(px => px.Pokemons)
            .WithOne(p => p.PokemonRecord);


        modelBuilder.Entity<PokemonAbility>()
            .HasKey(pa => new { pa.PokemonId, pa.AbilityId });
        modelBuilder.Entity<PokemonAbility>()
            .HasOne(p => p.Pokemon)
            .WithMany(pa => pa.PokemonAbilities)
            .HasForeignKey(a => a.PokemonId);
        modelBuilder.Entity<PokemonAbility>()
            .HasOne(p => p.Ability)
            .WithMany(pc => pc.PokemonAbilities)
            .HasForeignKey(c => c.AbilityId);

        modelBuilder.Entity<PokemonCategory>()
            .HasKey(pc => new { pc.PokemonId, pc.CategoryId });
        modelBuilder.Entity<PokemonCategory>()
            .HasOne(p => p.Pokemon)
            .WithMany(pc => pc.PokemonCategories)
            .HasForeignKey(p => p.PokemonId);
        modelBuilder.Entity<PokemonCategory>()
            .HasOne(p => p.Category)
            .WithMany(pc => pc.PokemonCategories)
            .HasForeignKey(c => c.CategoryId);

        modelBuilder.Entity<PokemonOwner>()
            .HasKey(po => new { po.PokemonId, po.UserId });
        modelBuilder.Entity<PokemonOwner>()
            .HasOne(p => p.Pokemon)
            .WithMany(pc => pc.PokemonOwners)
            .HasForeignKey(p => p.PokemonId);
        modelBuilder.Entity<PokemonOwner>()
            .HasOne(p => p.User)
            .WithMany(pc => pc.PokemonOwners)
            .HasForeignKey(c => c.UserId);
    }
}