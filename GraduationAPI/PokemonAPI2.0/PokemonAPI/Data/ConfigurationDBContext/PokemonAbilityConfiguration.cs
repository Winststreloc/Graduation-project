using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PokemonAPI;

namespace PokemonWEB.Data;

public class PokemonAbilityConfiguration : IEntityTypeConfiguration<PokemonAbility>
{
    public void Configure(EntityTypeBuilder<PokemonAbility> builder)
    {
        builder
            .HasKey(pa => new { pa.PokemonId, pa.AbilityId });
        builder
            .HasOne(p => p.Pokemon)
            .WithMany(pa => pa.PokemonAbilities)
            .HasForeignKey(a => a.PokemonId);
        builder
            .HasOne(p => p.Ability)
            .WithMany(pc => pc.PokemonAbilities)
            .HasForeignKey(c => c.AbilityId);
    }
}