using Microsoft.EntityFrameworkCore;
using PokemonAPI.Helpers;
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
            var pokedex = new List<Pokedex>()
            {
                new Pokedex()
                {
                    PokedexId = 1,
                    Name = "Бульбазавр",
                    BaseDamage = 49,
                    BaseDefense = 49,
                    BaseHP = 45,
                    Weight = 6.9,
                    Height = 0.62,
                    Description = "Этот покемон любит вздремнуть на солнышке. Его луковица растет за счет поглощения солнечных лучей.",
                    Category = "Grass",
                    NextEvol = 2,
                    MainUrl = "https://assets.pokemon.com/assets/cms2/img/pokedex/full/001.png",
                    PokEvol1 = "https://pokepower.ru/img/pokemons/anim/normal/1.gif",
                    PokEvol2 = "https://pokepower.ru/img/pokemons/anim/normal/2.gif",
                    PokEvol3 = "https://pokepower.ru/img/pokemons/anim/normal/3.gif"
                },
                new Pokedex()
                {
                    PokedexId = 2,
                    Name = "Ивизавр",
                    BaseDamage = 62,
                    BaseDefense = 63,
                    BaseHP = 60,
                    Weight = 13,
                    Height = 0.92,
                    Description = "На спине Ивизавра растёт огромное семя. Чтобы выдерживать вес, ноги и туловище " +
                                  "становятся более толстыми и прочными. Частое лежание на солнце предвещает скорое " +
                                  "расцветание семени в огромный цветок.",
                    Category = "Grass",
                    NextEvol = 3,
                    PrevEvol = 1,
                    MainUrl = "https://assets.pokemon.com/assets/cms2/img/pokedex/full/002.png",
                    PokEvol1 = "https://pokepower.ru/img/pokemons/anim/normal/1.gif",
                    PokEvol2 = "https://pokepower.ru/img/pokemons/anim/normal/2.gif",
                    PokEvol3 = "https://pokepower.ru/img/pokemons/anim/normal/3.gif"
                },
                new Pokedex()
                {
                    PokedexId = 3,
                    Name = "Венозавр",
                    BaseDamage = 82,
                    BaseDefense = 83,
                    BaseHP = 80,
                    Weight = 100,
                    Height = 1.85,
                    Description = "На спине Венозавра находится огромный цветок. Вбирая питательные вещества и солнечный цвет, " +
                                  "он приобретает яркие цвета. Аромат цветка способен успокаивать людей.",
                    Category = "Grass",
                    PrevEvol = 2,
                    MainUrl = "https://assets.pokemon.com/assets/cms2/img/pokedex/full/003.png",
                    PokEvol1 = "https://pokepower.ru/img/pokemons/anim/normal/1.gif",
                    PokEvol2 = "https://pokepower.ru/img/pokemons/anim/normal/2.gif",
                    PokEvol3 = "https://pokepower.ru/img/pokemons/anim/normal/3.gif"
                }
            };
            var pokemons = new List<Pokemon>()
            {
                new Pokemon()
                {
                    Id = new Guid("28de668a-4d83-4e14-adc1-b83ac929a272"),
                    Name = "Бульбазавр",
                    PokedexId = 1,
                    Gender = true,
                    Experience = 300,
                    CurrentHealth = 45,
                    CurrentDamage = 49,
                    CurrentDefence = 49
                },
                new Pokemon()
                {
                    Id = new Guid("692c9ef3-8483-44dd-ae01-08d80107551d"),
                    Name = "Ивизавр",
                    PokedexId = 2,
                    Gender = true,
                    Experience = 1806,
                    CurrentHealth = 60,
                    CurrentDamage = 62,
                    CurrentDefence = 63
                },
                new Pokemon()
                {
                    Id = new Guid("dacce0af-f1f9-4aa7-83a8-a49125589491"),
                    Name = "Венозавр",
                    PokedexId = 3,
                    Gender = true,
                    Experience = 300,
                    CurrentHealth = 80,
                    CurrentDamage = 82,
                    CurrentDefence = 83
                },
            };
            
            var pokemonCategory = new List<PokemonCategory>()
            {
                new PokemonCategory()
                {
                    PokemonId = Guid.Parse("28de668a-4d83-4e14-adc1-b83ac929a272"),
                    Category = new Category()
                    {
                        Id = new Guid("1cefd6b9-b3c8-4def-8198-38735da5d79a"),
                        Name = "Grass"
                    }
                    
                },
                new PokemonCategory()
                {
                    PokemonId = Guid.Parse("28de668a-4d83-4e14-adc1-b83ac929a272"),
                    Category = new Category()
                    {
                        Id = new Guid("3b0365c1-90f3-4ae4-ba76-620e20e56846"),
                        Name = "Poison"
                    }
                },
                new PokemonCategory()
                {
                    PokemonId = Guid.Parse("692c9ef3-8483-44dd-ae01-08d80107551d"),
                    CategoryId = Guid.Parse("1cefd6b9-b3c8-4def-8198-38735da5d79a"),
                },
                new PokemonCategory()
                {
                    PokemonId = Guid.Parse("692c9ef3-8483-44dd-ae01-08d80107551d"),
                    CategoryId = Guid.Parse("3b0365c1-90f3-4ae4-ba76-620e20e56846")
                },
                new PokemonCategory()
                {
                    PokemonId = Guid.Parse("dacce0af-f1f9-4aa7-83a8-a49125589491"),
                    CategoryId = Guid.Parse("1cefd6b9-b3c8-4def-8198-38735da5d79a"),
                },
                new PokemonCategory()
                {
                    PokemonId = Guid.Parse("dacce0af-f1f9-4aa7-83a8-a49125589491"),
                    CategoryId = Guid.Parse("3b0365c1-90f3-4ae4-ba76-620e20e56846")
                }
            };
            
            var pokemonOwner = new List<PokemonOwner>()
            {
                new PokemonOwner()
                {
                    PokemonId = Guid.Parse("28de668a-4d83-4e14-adc1-b83ac929a272"),
                    Owner = new Owner()
                    {
                        Id = new Guid("d92119ca-bd69-4f7c-822b-27487892c615"),
                        FirstName = "Yash",
                        LastName = "Ketchyp",
                        Gym = "PokeGym"
                    }
                },
                new PokemonOwner()
                {
                    PokemonId = Guid.Parse("692c9ef3-8483-44dd-ae01-08d80107551d"),
                    OwnerId = Guid.Parse("d92119ca-bd69-4f7c-822b-27487892c615")
                },
                new PokemonOwner()
                {
                    PokemonId = Guid.Parse("dacce0af-f1f9-4aa7-83a8-a49125589491"),
                    OwnerId = Guid.Parse("d92119ca-bd69-4f7c-822b-27487892c615")
                }
            };
            
            var pokemonAbility = new List<PokemonAbility>()
            {
                new PokemonAbility()
                {
                    PokemonId = Guid.Parse("28DE668A-4D83-4E14-ADC1-B83AC929A272"),
                    Ability = new Ability()
                    {
                        Id = 1,
                        Name = "Frontal Attack",
                        Damage = 10,
                        Healing = 0,
                    }
                },
                new PokemonAbility()
                {
                    PokemonId = Guid.Parse("692C9EF3-8483-44DD-AE01-08D80107551D"),
                    AbilityId = 1
                },
                new PokemonAbility()
                {
                    PokemonId = Guid.Parse("DACCE0AF-F1F9-4AA7-83A8-A49125589491"),
                    AbilityId = 1
                },
                new PokemonAbility()
                {
                    PokemonId = Guid.Parse("28DE668A-4D83-4E14-ADC1-B83AC929A272"),
                    Ability = new Ability()
                    {
                        Id = 2,
                        Name = "Photosynthesis",
                        Damage = 0,
                        Healing = 15,
                    }
                },
                new PokemonAbility()
                {
                    PokemonId = Guid.Parse("DACCE0AF-F1F9-4AA7-83A8-A49125589491"),
                    AbilityId = 2
                },
                new PokemonAbility()
                {
                    PokemonId = Guid.Parse("692C9EF3-8483-44DD-AE01-08D80107551D"),
                    AbilityId = 2
                },

            };
            
            _pokemonDbContext.Pokedex.AddRange(pokedex);
            _pokemonDbContext.SaveChangesWithIdentityInsert<Pokedex>();
            _pokemonDbContext.Pokemons.AddRange(pokemons);
            _pokemonDbContext.PokemonCategories.AddRange(pokemonCategory);
            _pokemonDbContext.PokemonOwners.AddRange(pokemonOwner);
            _pokemonDbContext.SaveChangesWithIdentityInsert<Ability>();
            _pokemonDbContext.PokemonAbilities.AddRange(pokemonAbility);
            _pokemonDbContext.SaveChanges();
        }
    }
}