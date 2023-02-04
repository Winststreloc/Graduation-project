using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PokemonAPI.Models;

namespace PokemonWEB.Data;

public class PokRecCategoryConfiguration : IEntityTypeConfiguration<PokemonRecordCategory>
{
    public void Configure(EntityTypeBuilder<PokemonRecordCategory> builder)
    {
        builder
            .HasKey(pc => new { pc.PokemonRecordId, pc.CategoryId });
        builder
            .HasOne(p => p.PokemonRecord)
            .WithMany(pc => pc.PokemonRecordCategories)
            .HasForeignKey(p => p.PokemonRecordId);
        builder
            .HasOne(p => p.Category)
            .WithMany(pc => pc.PokemonRecordCategories)
            .HasForeignKey(c => c.CategoryId);
    }
}