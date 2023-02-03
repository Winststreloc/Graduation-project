using Microsoft.EntityFrameworkCore;
using PokemonAPI.Helpers;
using PokemonAPI.Interfaces;
using PokemonAPI.Models;
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
        if (!_pokemonDbContext.Users.Any())
        {
            var users = new List<User>()
            {
                new User()
                {
                    Id = new Guid("b0eac7fa-006c-424f-bf60-25819adfb1ae"),
                    Email = "ashKetchum@gmail.com",
                    FirstName = "Ash",
                    LastName = "Ketchum",
                    Gender = Gender.Male,
                    NickName = "ashKetchum",
                    PasswordHash = _passwordHashing.HashingPassword("secretPassword"),
                    Roles = Roles.User
                },
                new User()
                {
                    Id = new Guid("4ec95354-9532-4c2c-9bff-2dc8fff4fb73"),
                    NickName = "Martin",
                    Email = "martin@gmail.com",
                    Roles = Roles.Admin,
                    PasswordHash = _passwordHashing.HashingPassword("martin"),
                }
                
            };
            _pokemonDbContext.AddRange(users);
            _pokemonDbContext.SaveChanges();
        }
        if (!_pokemonDbContext.Pokedex.Any())
        {
            var pokedex = new List<PokemonRecord>()
            {
                new PokemonRecord()
                {
                    Id = 1,
                    Name = "Bulbasaur",
                    BaseDamage = 49,
                    BaseDefense = 49,
                    BaseHP = 45,
                    Weight = 6.9,
                    Height = 0.62,
                    Description =
                        "There is a plant seed on its back right from the day this Pokémon is born. The seed slowly grows larger.",
                    Category = "Grass",
                    NextEvol = 2,
                    MainUrl = "https://assets.pokemon.com/assets/cms2/img/pokedex/full/001.png",
                    PokEvol1 = "https://pokepower.ru/img/pokemons/anim/normal/1.gif",
                    PokEvol2 = "https://pokepower.ru/img/pokemons/anim/normal/2.gif",
                    PokEvol3 = "https://pokepower.ru/img/pokemons/anim/normal/3.gif"
                },
                new PokemonRecord()
                {
                    Id = 2,
                    Name = "Ivysaur",
                    BaseDamage = 62,
                    BaseDefense = 63,
                    BaseHP = 60,
                    Weight = 13,
                    Height = 0.92,
                    Description =
                        "When the bulb on its back grows large, it appears to lose the ability to stand on its hind legs.",
                    Category = "Grass",
                    NextEvol = 3,
                    PrevEvol = 1,
                    MainUrl = "https://assets.pokemon.com/assets/cms2/img/pokedex/full/002.png",
                    PokEvol1 = "https://pokepower.ru/img/pokemons/anim/normal/1.gif",
                    PokEvol2 = "https://pokepower.ru/img/pokemons/anim/normal/2.gif",
                    PokEvol3 = "https://pokepower.ru/img/pokemons/anim/normal/3.gif"
                },
                new PokemonRecord()
                {
                    Id = 3,
                    Name = "Venusaur",
                    BaseDamage = 82,
                    BaseDefense = 83,
                    BaseHP = 80,
                    Weight = 100,
                    Height = 1.85,
                    Description =
                        "Its plant blooms when it is absorbing solar energy. It stays on the move to seek sunlight.",
                    Category = "Grass",
                    PrevEvol = 2,
                    MainUrl = "https://assets.pokemon.com/assets/cms2/img/pokedex/full/003.png",
                    PokEvol1 = "https://pokepower.ru/img/pokemons/anim/normal/1.gif",
                    PokEvol2 = "https://pokepower.ru/img/pokemons/anim/normal/2.gif",
                    PokEvol3 = "https://pokepower.ru/img/pokemons/anim/normal/3.gif"
                },
                new PokemonRecord()
                {
                    Id = 004,
                    Name = "Charmander",
                    BaseDamage = 52,
                    BaseDefense = 43,
                    BaseHP = 39,
                    Weight = 8.5,
                    Height = 0.6,
                    Description = "It has a preference for hot things. When it rains, steam is said to spout from the tip of its tail.",
                    Category = "Fire",
                    MainUrl = "https://assets.pokemon.com/assets/cms2/img/pokedex/full/004.png",
                    PokEvol1 = "https://pokepower.ru/img/pokemons/main/front/normal/004.gif",
                    PokEvol2 = "https://pokepower.ru/img/pokemons/main/front/normal/005.gif",
                    PokEvol3 = "https://pokepower.ru/img/pokemons/main/front/normal/006.gif"
                }
            };
            _pokemonDbContext.AddRange(pokedex);
            _pokemonDbContext.SaveChangesWithIdentityInsert<PokemonRecord>();
        }
        if (!_pokemonDbContext.Pokemons.Any())
        {
            var pokemons = new List<Pokemon>()
            {
                new Pokemon()
                {
                    Id = new Guid("28de668a-4d83-4e14-adc1-b83ac929a272"),
                    Name = "Bulbasaur",
                    PokemonRecordId = 1,
                    Gender = true,
                    Experience = 300,
                    CurrentHealth = 45,
                    CurrentDamage = 49,
                    CurrentDefence = 49,
                    UserId = Guid.Parse("4ec95354-9532-4c2c-9bff-2dc8fff4fb73"),
                },
                new Pokemon()
                {
                    Id = new Guid("692c9ef3-8483-44dd-ae01-08d80107551d"),
                    Name = "Ivysaur",
                    PokemonRecordId = 2,
                    Gender = true,
                    Experience = 1806,
                    CurrentHealth = 60,
                    CurrentDamage = 62,
                    CurrentDefence = 63,
                    UserId = Guid.Parse("4ec95354-9532-4c2c-9bff-2dc8fff4fb73")
                },
                new Pokemon()
                {
                    Id = new Guid("dacce0af-f1f9-4aa7-83a8-a49125589491"),
                    Name = "Venusaur",
                    Gender = true,
                    PokemonRecordId = 3,
                    Experience = 300,
                    CurrentHealth = 80,
                    CurrentDamage = 82,
                    CurrentDefence = 83,
                    UserId = Guid.Parse("4ec95354-9532-4c2c-9bff-2dc8fff4fb73")
                },
            };
            
            _pokemonDbContext.Pokemons.AddRange(pokemons);
            _pokemonDbContext.SaveChanges();
        }
        if (!_pokemonDbContext.Abilities.Any())
        {
            var abilities = new List<Ability>()
            {
                new Ability()
                {
                    Name = "Frontal Attack",
                    Damage = 40,
                    Healing = 0,
                    Description = "The Pokémon accelerates and rams the opponent with its body.",
                    ImageUrl = "https://pokepower.ru/img/world/typs/normal.png"
                },
                new Ability()
                {
                    Name = "Photosynthesis",
                    Damage = 0,
                    Healing = 30,
                    Description =
                        "The Pokémon's body is covered with a bright and brilliant white light that heals wounds ",
                    ImageUrl = "https://pokepower.ru/img/world/typs/grass.png"
                },
                new Ability()
                {
                    Name = "Vine Whip",
                    Damage = 45,
                    Description = "Pokemon whips the opponent with long vines.",
                    ImageUrl = "https://pokepower.ru/img/world/typs/grass.png"
                },
                new Ability()
                {
                    Name = "Ember",
                    Damage = 40,
                    Description = "The Pokémon fires small bursts of flame at the enemy.",
                    ImageUrl = "https://pokepower.ru/img/world/typs/fire.png"
                }
            };

            var categoryes = new List<Category>()
            {
                new Category()
                {
                    Name = "Grass",
                    ImageUrl = "https://pokepower.ru/img/world/typs/grass.png",
                },
                new Category()
                {
                    Name = "Eart",
                    ImageUrl = "https://pokepower.ru/img/world/typs/grass.png"
                },
                new Category()
                {
                    Name = "Fire",
                    ImageUrl = "https://pokepower.ru/img/world/typs/fire.png"
                }
            };
            
            _pokemonDbContext.AddRange(abilities);
            _pokemonDbContext.AddRange(categoryes);
            _pokemonDbContext.SaveChanges();
        }
        if (!_pokemonDbContext.PokemonAbilities.Any())
        {
            var abilities = new List<PokemonAbility>()
            {
                new PokemonAbility()
                {
                    AbilityId = 1,
                    PokemonId = Guid.Parse("28de668a-4d83-4e14-adc1-b83ac929a272")
                },
                new PokemonAbility()
                {
                    AbilityId = 1,
                    PokemonId = Guid.Parse("692c9ef3-8483-44dd-ae01-08d80107551d")
                },
                new PokemonAbility()
                {
                    AbilityId = 2,
                    PokemonId = Guid.Parse("692c9ef3-8483-44dd-ae01-08d80107551d")
                },
                new PokemonAbility()
                {
                    AbilityId = 1,
                    PokemonId = Guid.Parse("dacce0af-f1f9-4aa7-83a8-a49125589491")
                },
                new PokemonAbility()
                {
                    AbilityId = 2,
                    PokemonId = Guid.Parse("dacce0af-f1f9-4aa7-83a8-a49125589491")
                }
            };
            _pokemonDbContext.AddRange(abilities);
            _pokemonDbContext.SaveChanges();
        }
        if (!_pokemonDbContext.PokemonCategories.Any())
        {
            var categories = new List<PokemonCategory>()
            {
                new PokemonCategory()
                {
                    PokemonId = Guid.Parse("28de668a-4d83-4e14-adc1-b83ac929a272"),
                    CategoryId = 1
                },
                new PokemonCategory()
                {
                    PokemonId = Guid.Parse("692c9ef3-8483-44dd-ae01-08d80107551d"),
                    CategoryId = 1
                },
                new PokemonCategory()
                {
                    PokemonId = Guid.Parse("692c9ef3-8483-44dd-ae01-08d80107551d"),
                    CategoryId = 2
                },
                new PokemonCategory()
                {
                    PokemonId = Guid.Parse("dacce0af-f1f9-4aa7-83a8-a49125589491"),
                    CategoryId = 1
                },
                new PokemonCategory()
                {
                    PokemonId = Guid.Parse("dacce0af-f1f9-4aa7-83a8-a49125589491"),
                    CategoryId = 2
                }
            };
            _pokemonDbContext.AddRange(categories);
            _pokemonDbContext.SaveChanges();
        }
        
    }
}