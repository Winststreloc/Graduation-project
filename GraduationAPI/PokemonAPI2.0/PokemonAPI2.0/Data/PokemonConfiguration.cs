using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PokemonWEB.Models;

namespace PokemonWEB.Data;

public class PokemonConfiguration : IEntityTypeConfiguration<Pokemon> //TODO
{
    public void Configure(EntityTypeBuilder<Pokemon> builder)
    {
        
    }
}