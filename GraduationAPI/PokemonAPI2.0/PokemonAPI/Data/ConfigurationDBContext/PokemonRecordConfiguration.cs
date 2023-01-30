using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PokemonWEB.Models;

namespace PokemonWEB.Data;

public class PokemonRecordConfiguration : IEntityTypeConfiguration<PokemonRecord>
{
    public void Configure(EntityTypeBuilder<PokemonRecord> builder)
    {
        builder
            .HasKey(p => p.Id);
    }
}