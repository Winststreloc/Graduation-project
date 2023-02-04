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
                    Id = 001,
                    Name = "Bulbasaur",
                    BaseDamage = 49,
                    BaseDefense = 49,
                    BaseHP = 45,
                    Weight = 6.9,
                    Height = 0.62,
                    PokemonPower = 35,
                    Description =
                        "There is a plant seed on its back right from the day this Pokémon is born. The seed slowly grows larger.",
                    NextEvol = 2,
                    MainUrl = "https://pokepower.ru/img/pokemons/main/front/normal/001.gif",
                    PokEvol1 = "https://pokepower.ru/img/pokemons/anim/normal/1.gif",
                    PokEvol2 = "https://pokepower.ru/img/pokemons/anim/normal/2.gif",
                    PokEvol3 = "https://pokepower.ru/img/pokemons/anim/normal/3.gif"
                },
                new PokemonRecord()
                {
                    Id = 002,
                    Name = "Ivysaur",
                    BaseDamage = 62,
                    BaseDefense = 63,
                    BaseHP = 60,
                    Weight = 13,
                    Height = 0.92,
                    PokemonPower = 35,
                    Description =
                        "A huge seed grows on the back of the Ivysaur. To support the weight, the legs and torso become thicker and stronger. " +
                        "Frequent lying in the sun portends the imminent flowering of the seed into a huge flower.",
                    NextEvol = 3,
                    PrevEvol = 1,
                    MainUrl = "https://pokepower.ru/img/pokemons/main/front/normal/002.gif",
                    PokEvol1 = "https://pokepower.ru/img/pokemons/anim/normal/1.gif",
                    PokEvol2 = "https://pokepower.ru/img/pokemons/anim/normal/2.gif",
                    PokEvol3 = "https://pokepower.ru/img/pokemons/anim/normal/3.gif"
                },
                new PokemonRecord()
                {
                    Id = 003,
                    Name = "Venusaur",
                    BaseDamage = 82,
                    BaseDefense = 83,
                    BaseHP = 80,
                    Weight = 100,
                    Height = 1.85,
                    PokemonPower = 35,
                    Description =
                        "On the back of Venosaurus is a huge flower. By absorbing nutrients and sunlight, " +
                        "it acquires bright colors. The fragrance of a flower can calm people down.",
                    PrevEvol = 2,
                    MainUrl = "https://pokepower.ru/img/pokemons/main/front/normal/003.gif",
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
                    PokemonPower = 35,
                    Description = "The fire at the tip of the tail shows Charmander's emotions. The swaying flame speaks of the contentment of the Pokémon. " +
                                  "A fiercely burning flame signifies rage.",
                    MainUrl = "https://pokepower.ru/img/pokemons/main/front/normal/004.gif",
                    PokEvol1 = "https://pokepower.ru/img/pokemons/anim/normal/4.gif",
                    PokEvol2 = "https://pokepower.ru/img/pokemons/anim/normal/5.gif",
                    PokEvol3 = "https://pokepower.ru/img/pokemons/anim/normal/6.gif"
                },
                new PokemonRecord()
                {
                    Id = 005,
                    Name = "Charmeleon",
                    BaseDamage = 64,
                    BaseDefense = 58,
                    BaseHP = 58,
                    Weight = 19,
                    Height = 1.1,
                    PokemonPower = 35,
                    Description = "Charmeleon mercilessly exterminates enemies using sharp claws. Strong opponents cause special aggression. " +
                                  "When enraged, the flame at the tip of the Pokémon's tail glows a bluish-white hue.",
                    MainUrl = "https://pokepower.ru/img/pokemons/main/front/normal/005.gif",
                    PokEvol1 = "https://pokepower.ru/img/pokemons/anim/normal/4.gif",
                    PokEvol2 = "https://pokepower.ru/img/pokemons/anim/normal/5.gif",
                    PokEvol3 = "https://pokepower.ru/img/pokemons/anim/normal/6.gif"
                },
                new PokemonRecord()
                {
                    Id = 006,
                    Name = "Charmeleon",
                    BaseDamage = 84,
                    BaseDefense = 78,
                    BaseHP = 78,
                    Weight = 90.5,
                    Height = 1.7,
                    PokemonPower = 35,
                    Description = "It has a preference for hot things. When it rains, steam is said to spout from the tip of its tail.",
                    MainUrl = "https://pokepower.ru/img/pokemons/main/front/normal/006.gif",
                    PokEvol1 = "https://pokepower.ru/img/pokemons/anim/normal/4.gif",
                    PokEvol2 = "https://pokepower.ru/img/pokemons/anim/normal/5.gif",
                    PokEvol3 = "https://pokepower.ru/img/pokemons/anim/normal/6.gif"
                },
                new PokemonRecord()
                {
                    Id = 007,
                    Name = "Squirtle",
                    BaseDamage = 48,
                    BaseDefense = 65,
                    BaseHP = 44,
                    Weight = 9.0,
                    Height = 0.5,
                    PokemonPower = 35,
                    Description = "It has a preference for hot things. When it rains, steam is said to spout from the tip of its tail.",
                    MainUrl = "https://pokepower.ru/img/pokemons/main/front/normal/007.gif",
                    PokEvol1 = "https://pokepower.ru/img/pokemons/anim/normal/7.gif",
                    PokEvol2 = "https://pokepower.ru/img/pokemons/anim/normal/8.gif",
                    PokEvol3 = "https://pokepower.ru/img/pokemons/anim/normal/8.gif"
                },
                new PokemonRecord()
                {
                    Id = 008,
                    Name = "Wartortle",
                    BaseDamage = 63,
                    BaseDefense = 80,
                    BaseHP = 59,
                    Weight = 22.5,
                    Height = 1.0,
                    PokemonPower = 35,
                    Description = "It has a preference for hot things. When it rains, steam is said to spout from the tip of its tail.",
                    MainUrl = "https://pokepower.ru/img/pokemons/main/front/normal/008.gif",
                    PokEvol1 = "https://pokepower.ru/img/pokemons/anim/normal/7.gif",
                    PokEvol2 = "https://pokepower.ru/img/pokemons/anim/normal/8.gif",
                    PokEvol3 = "https://pokepower.ru/img/pokemons/anim/normal/9.gif"
                },
                new PokemonRecord()
                {
                    Id = 009,
                    Name = "Blastoise",
                    BaseDamage = 83,
                    BaseDefense = 100,
                    BaseHP = 79,
                    Weight = 90.5,
                    Height = 1.7,
                    PokemonPower = 35,
                    Description = "It has a preference for hot things. When it rains, steam is said to spout from the tip of its tail.",
                    MainUrl = "https://pokepower.ru/img/pokemons/main/front/normal/009.gif",
                    PokEvol1 = "https://pokepower.ru/img/pokemons/anim/normal/7.gif",
                    PokEvol2 = "https://pokepower.ru/img/pokemons/anim/normal/8.gif",
                    PokEvol3 = "https://pokepower.ru/img/pokemons/anim/normal/9.gif"
                },
                new PokemonRecord()
                {
                    Id = 010,
                    Name = "Caterpie",
                    BaseDamage = 30,
                    BaseDefense = 35,
                    BaseHP = 45,
                    Weight = 2.9,
                    Height = 0.3,
                    PokemonPower = 35,
                    Description = "It has a preference for hot things. When it rains, steam is said to spout from the tip of its tail.",
                    MainUrl = "https://pokepower.ru/img/pokemons/main/front/normal/010.gif",
                    PokEvol1 = "https://pokepower.ru/img/pokemons/anim/normal/10.gif",
                    PokEvol2 = "https://pokepower.ru/img/pokemons/anim/normal/11.gif",
                    PokEvol3 = "https://pokepower.ru/img/pokemons/anim/normal/12.gif"
                },
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
                new Pokemon()
                {
                    Id = new Guid("dacce0af-f1f9-4aa7-83a8-a49125589491"),
                    Name = "Charmander",
                    Gender = true,
                    PokemonRecordId = 4,
                    Experience = 300,
                    CurrentHealth = 39,
                    CurrentDamage = 52,
                    CurrentDefence = 43,
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
                },
                new Ability()
                {
                    Name = "Fire Fang",
                    Damage = 65,
                    Description = "The Pokémon bites the opponent hard with its sharp fangs wrapped in hot flames.",
                    ImageUrl = "https://pokepower.ru/img/world/typs/fire.png"
                },
                new Ability()
                {
                    Name = "Fire Spin",
                    Damage = 35,
                    Description = "The Pokémon unleashes a raging blast of fire at the enemy, which encases the target in a searing fire trap.",
                    ImageUrl = "https://pokepower.ru/img/world/typs/fire.png"
                },
                
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
                    Name = "Earth",
                    ImageUrl = "https://pokepower.ru/img/world/typs/grass.png"
                },
                new Category()
                {
                    Name = "Fire",
                    ImageUrl = "https://pokepower.ru/img/world/typs/fire.png"
                },
                new Category()
                {
                    Name = "Poison",
                    ImageUrl = "https://pokepower.ru/img/world/typs/poison.png"
                },
                new Category()
                {
                    Name = "Dragon",
                    ImageUrl = "https://pokepower.ru/img/world/typs/fly.png"
                },
                new Category()
                {
                    Name = "Water",
                    ImageUrl = "https://pokepower.ru/img/world/typs/water.png"
                },
                new Category()
                {
                    Name = "Bug",
                    ImageUrl = "https://pokepower.ru/img/world/typs/bug.png"
                },
                new Category()
                {
                    Name = "Electric",
                    ImageUrl = "https://pokepower.ru/img/world/typs/electric.png"
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
                    PokemonId = Guid.Parse("28de668a-4d83-4e14-adc1-b83ac929a272"),
                    CategoryId = 4
                },
                new PokemonCategory()
                {
                    PokemonId = Guid.Parse("692c9ef3-8483-44dd-ae01-08d80107551d"),
                    CategoryId = 1
                },
                new PokemonCategory()
                {
                    PokemonId = Guid.Parse("692c9ef3-8483-44dd-ae01-08d80107551d"),
                    CategoryId = 4
                },
                new PokemonCategory()
                {
                    PokemonId = Guid.Parse("dacce0af-f1f9-4aa7-83a8-a49125589491"),
                    CategoryId = 1
                },
                new PokemonCategory()
                {
                    PokemonId = Guid.Parse("dacce0af-f1f9-4aa7-83a8-a49125589491"),
                    CategoryId = 4
                }
            };
            _pokemonDbContext.AddRange(categories);
            _pokemonDbContext.SaveChanges();
        }
        if (!_pokemonDbContext.PokemonRecordCategories.Any())
        {
            var pokRecordCategory = new List<PokemonRecordCategory>()
            {
                new PokemonRecordCategory()
                {
                    PokemonRecordId = 1,
                    CategoryId = 1
                },
                new PokemonRecordCategory()
                {
                    PokemonRecordId = 1,
                    CategoryId = 4
                },
                new PokemonRecordCategory()
                {
                    PokemonRecordId = 2,
                    CategoryId = 1
                },
                new PokemonRecordCategory()
                {
                    PokemonRecordId = 2,
                    CategoryId = 4
                },
                new PokemonRecordCategory()
                {
                    PokemonRecordId = 3,
                    CategoryId = 1
                },
                new PokemonRecordCategory()
                {
                    PokemonRecordId = 3,
                    CategoryId = 4
                },
                new PokemonRecordCategory()
                {
                    PokemonRecordId = 4,
                    CategoryId = 3
                },
                new PokemonRecordCategory()
                {
                    PokemonRecordId = 5,
                    CategoryId = 3
                },
                new PokemonRecordCategory()
                {
                    PokemonRecordId = 6,
                    CategoryId = 5
                },
                new PokemonRecordCategory()
                {
                    PokemonRecordId = 7,
                    CategoryId = 6
                },
                new PokemonRecordCategory()
                {
                    PokemonRecordId = 8,
                    CategoryId = 6
                },
                new PokemonRecordCategory()
                {
                    PokemonRecordId = 9,
                    CategoryId = 6
                },
                new PokemonRecordCategory()
                {
                    PokemonRecordId = 10,
                    CategoryId = 7
                }
                
            };
            _pokemonDbContext.AddRange(pokRecordCategory);
            _pokemonDbContext.SaveChanges();
        }
        
    }
}