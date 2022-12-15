using PokemonWEB.Data;
using PokemonWEB.Models;
using PokemonWEB.Models.Action;

namespace PokemonAPI;

public class Seed
{
    private readonly PokemonDbContext _pokemonDbContext;

    public Seed(PokemonDbContext context)
    {
        _pokemonDbContext = context;
    }

    public void SeedDataContext()
    {
        if (!_pokemonDbContext.Pokedex.Any())
        {
            var pokemons = new List<Pokedex>
            {
                new()
                {
                    PokedexId = 1,
                    Name = "Bulbasur",
                    Weight = 7,
                    Height = 70,
                    BaseDamage = 49,
                    BaseHP = 45,
                    BaseDefense = 49
                },
                new()
                {
                    PokedexId = 2,
                    Name = "Invsyr",
                    Weight = 13,
                    Height = 100,
                    BaseDamage = 60,
                    BaseHP = 62,
                    BaseDefense = 63
                },
                new()
                {
                    PokedexId = 3,
                    Name = "Venuasaur",
                    Weight = 100,
                    Height = 200,
                    BaseDamage = 80,
                    BaseHP = 82,
                    BaseDefense = 83
                }
            };
            _pokemonDbContext.SaveChanges();
        }
    }
}