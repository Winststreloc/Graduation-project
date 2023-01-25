using PokemonAPI.Helpers;
using PokemonAPI.Interfaces;
using PokemonAPI.Models.Enums;
using PokemonWEB.Data;
using PokemonWEB.Models;
using PokemonWEB.Models.Action;

namespace PokemonAPI;

public class Seed
{
    private readonly PokemonDbContext _pokemonDbContext;
    private readonly IPasswordHashingService _passwordHashing;
    public Seed(PokemonDbContext context, IPasswordHashingService passwordHashing)
    {
        _pokemonDbContext = context;
        _passwordHashing = passwordHashing;
    }

    public void SeedDataContext()
    {
        if (!_pokemonDbContext.Pokemons.Any())
        {
            var pokedex = new List<Pokedex>()
            {
                new Pokedex()
                {
                    PokedexId = 1,
                    Name = "Bulbasaur",
                    BaseDamage = 49,
                    BaseDefense = 49,
                    BaseHP = 45,
                    Weight = 6.9,
                    Height = 0.62,
                    Description = "There is a plant seed on its back right from the day this Pokémon is born. The seed slowly grows larger.",
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
                    Name = "Ivysaur",
                    BaseDamage = 62,
                    BaseDefense = 63,
                    BaseHP = 60,
                    Weight = 13,
                    Height = 0.92,
                    Description = "When the bulb on its back grows large, it appears to lose the ability to stand on its hind legs.",
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
                    Name = "Venusaur ",
                    BaseDamage = 82,
                    BaseDefense = 83,
                    BaseHP = 80,
                    Weight = 100,
                    Height = 1.85,
                    Description = "Its plant blooms when it is absorbing solar energy. It stays on the move to seek sunlight.",
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
                    User = new User()
                    {
                        Id = new Guid("d92119ca-bd69-4f7c-822b-27487892c615"),
                        FirstName = "Yash",
                        LastName = "Ketchyp",
                        NickName = "YashKetchup",
                        Email = "yashkethyp@gmail.com",
                        Roles = Roles.User,
                        PasswordHash = _passwordHashing.HashingPassword("yash")
                        
                    }
                },
                new PokemonOwner()
                {
                    PokemonId = Guid.Parse("692c9ef3-8483-44dd-ae01-08d80107551d"),
                    User = new User()
                    {
                        Id = Guid.Parse("5edb66d9-9a98-4470-8959-f19d1b461bfb"),
                        NickName = "Martin",
                        Email = "martin@gmail.com",
                        Roles = Roles.Admin,
                        PasswordHash = _passwordHashing.HashingPassword("martin")
                    }
                },
                new PokemonOwner()
                {
                    PokemonId = Guid.Parse("dacce0af-f1f9-4aa7-83a8-a49125589491"),
                    User = new User()
                    {
                        Id = Guid.Parse("d919663a-0768-464c-b1de-90f97de8d2f3"),
                        FirstName = "Arseny",
                        LastName = "Stefanenko",
                        NickName = "winst",
                        Email = "winst@gmail.com",
                        Roles = Roles.Admin,
                        PasswordHash = _passwordHashing.HashingPassword("1234")
                    }
                }
            };
            
            var pokemonAbility = new List<PokemonAbility>()
            {
                new PokemonAbility()
                {
                    PokemonId = Guid.Parse("28DE668A-4D83-4E14-ADC1-B83AC929A272"),
                    Ability = new Ability()
                    {
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
            _pokemonDbContext.Pokemons.AddRange(pokemons);
            _pokemonDbContext.PokemonCategories.AddRange(pokemonCategory);
            _pokemonDbContext.PokemonOwners.AddRange(pokemonOwner);
            _pokemonDbContext.PokemonAbilities.AddRange(pokemonAbility);
            _pokemonDbContext.SaveChangesWithIdentityInsert<Pokedex>();
            _pokemonDbContext.SaveChanges();
        }
    }
}