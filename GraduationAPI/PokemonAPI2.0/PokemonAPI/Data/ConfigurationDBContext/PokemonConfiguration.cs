using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PokemonAPI;
using PokemonWEB.Models;

namespace PokemonWEB.Data;

public class PokemonConfiguration : IEntityTypeConfiguration<Pokemon>
{
    public void Configure(EntityTypeBuilder<Pokemon> builder)
    {
        builder
            .HasOne(p => p.User)
            .WithMany(c => c.Pokemons)
            .HasForeignKey(p => p.UserId);
        builder
            .HasOne(p => p.Battle)
            .WithMany(b => b.Pokemons)
            .HasForeignKey(p => p.BattleId);
    }
}