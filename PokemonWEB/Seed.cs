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
        if (!_pokemonDbContext.PokemonOwners.Any())
        {
            var pokemonOwners = new List<PokemonOwner>
            {
                new()
                {
                    Pokemon = new Pokemon
                    {
                        Id = new Guid(),
                        Name = "Bulbasaur",
                        Weight = 7,
                        Height = 70,
                        Gender = true,
                        Experiance = 100,
                        PokemonCategories = new List<PokemonCategory>
                        {
                            new() { Category = new Category { Id = new Guid(), Name = "Grass" } },
                            new() { Category = new Category { Id = new Guid(), Name = "Poison"} }
                        },
                        PokemonAbilities = new List<PokemonAbility>
                        {
                            new() {Ability = new Ability {Name = "Frontal attack", Damage = 40, Healing = 0, Id = new Guid()}}
                        }
                    },
                    Owner = new Owner
                    {
                        Id = new Guid(),
                        FirstName = "Jack",
                        LastName = "London",
                        Gym = "Brocks Gym",
                    }
                },
                new()
                {
                    Pokemon = new Pokemon
                    {
                        Id = new Guid(),
                        Name = "Ivysaur",
                        Weight = 13,
                        Height = 100,
                        Gender = true,
                        Experiance = 1600,
                        PokemonCategories = new List<PokemonCategory>
                        {
                            new() { Category = new Category { Id = new Guid(), Name = "Grass" } },
                            new() { Category = new Category { Id = new Guid(), Name = "Poison"} }
                        },
                        PokemonAbilities = new List<PokemonAbility>
                        {
                            new() {Ability = new Ability {Name = "Frontal attack", Damage = 40, Healing = 0, Id = new Guid()}}
                        }
                    },
                    Owner = new Owner
                    {
                        Id = new Guid(),
                        FirstName = "Harry",
                        LastName = "Potter",
                        Gym = "Mistys Gym",
                    }
                },
                new()
                {
                    Pokemon = new Pokemon
                    {
                        Id = new Guid(),
                        Name = "Ivysaur",
                        Weight = 100,
                        Height = 200,
                        Gender = true,
                        Experiance = 3600,
                        PokemonCategories = new List<PokemonCategory>
                        {
                            new() { Category = new Category { Id = new Guid(), Name = "Grass" } },
                            new() { Category = new Category { Id = new Guid(), Name = "Poison"} }
                        },
                        PokemonAbilities = new List<PokemonAbility>
                        {
                            new() {Ability = new Ability {Name = "Frontal attack", Damage = 40, Healing = 0, Id = new Guid()}}
                        }
                    },
                    Owner = new Owner
                    {
                        Id = new Guid(),
                        FirstName = "Ash",
                        LastName = "Ketchum",
                        Gym = "Ashs Gym",
                    }
                }
            };
            _pokemonDbContext.PokemonOwners.AddRange(pokemonOwners);
            _pokemonDbContext.SaveChanges();
        }
    }
}