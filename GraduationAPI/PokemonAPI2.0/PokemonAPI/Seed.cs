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
        if (!_pokemonDbContext.Pokemons.Any())
        {
            var userMartin = new User()
            {
                NickName = "Martin",
                Email = "martin@gmail.com",
                Roles = Roles.Admin,
                PasswordHash = _passwordHashing.HashingPassword("martin"),
            };
            var bulbasaur = new PokemonRecord()
            {
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
            };
            var ivysaur = new PokemonRecord()
            {
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
            };
            var venusaur = new PokemonRecord()
            {
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
            };
            var grassCategory = new Category()
            {
                Name = "Grass",
                ImageUrl = "https://pokepower.ru/img/world/typs/grass.png",
            };
            var eartCategory = new Category()
            {
                Name = "Eart",
                ImageUrl = "https://pokepower.ru/img/world/typs/grass.png"
            };
            var frontalAttack = new Ability()
            {
                Name = "Frontal Attack",
                Damage = 10,
                Healing = 0,
                Description = "The Pokémon accelerates and rams the opponent with its body.",
                ImageUrl = "https://pokepower.ru/img/world/typs/normal.png"
            };
            var photosintes = new Ability()
            {
                Name = "Photosynthesis",
                Damage = 0,
                Healing = 15,
                Description =
                    "The Pokémon's body is covered with a bright and brilliant white light that heals wounds ",
                ImageUrl = "https://pokepower.ru/img/world/typs/grass.png"
            };

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
                    User = userMartin,
                    PokemonRecord = bulbasaur,
                    PokemonCategories = new List<PokemonCategory>()
                    {
                        new PokemonCategory()
                        {
                            PokemonId = Guid.Parse("28de668a-4d83-4e14-adc1-b83ac929a272"),
                            Category = grassCategory
                        }
                    },
                    PokemonAbilities = new List<PokemonAbility>()
                    {
                        new PokemonAbility()
                        {
                            Ability = frontalAttack,
                            PokemonId = Guid.Parse("28de668a-4d83-4e14-adc1-b83ac929a272")
                        }
                    }
                },
                new Pokemon()
                {
                    Id = new Guid("692c9ef3-8483-44dd-ae01-08d80107551d"),
                    Name = "Ивизавр",
                    PokemonRecordId = 2,
                    Gender = true,
                    Experience = 1806,
                    CurrentHealth = 60,
                    CurrentDamage = 62,
                    CurrentDefence = 63,
                    User = userMartin,
                    PokemonRecord = ivysaur,
                    PokemonCategories = new List<PokemonCategory>()
                    {
                        new PokemonCategory()
                        {
                            PokemonId = Guid.Parse("692c9ef3-8483-44dd-ae01-08d80107551d"),
                            Category = grassCategory
                        },
                        new PokemonCategory()
                        {
                            PokemonId = Guid.Parse("692c9ef3-8483-44dd-ae01-08d80107551d"),
                            Category = eartCategory
                        }
                    },
                    PokemonAbilities = new List<PokemonAbility>()
                    {
                        new PokemonAbility()
                        {
                            Ability = frontalAttack,
                            PokemonId = Guid.Parse("692c9ef3-8483-44dd-ae01-08d80107551d")
                        },
                        new PokemonAbility()
                        {
                            Ability = photosintes,
                            PokemonId = Guid.Parse("692c9ef3-8483-44dd-ae01-08d80107551d")
                        }
                    }
                },
                new Pokemon()
                {
                    Id = new Guid("dacce0af-f1f9-4aa7-83a8-a49125589491"),
                    Name = "Венозавр",
                    Gender = true,
                    PokemonRecordId = 3,
                    Experience = 300,
                    CurrentHealth = 80,
                    CurrentDamage = 82,
                    CurrentDefence = 83,
                    User = userMartin,
                    PokemonRecord = venusaur,
                    PokemonCategories = new List<PokemonCategory>()
                    {
                        new PokemonCategory()
                        {
                            PokemonId = Guid.Parse("dacce0af-f1f9-4aa7-83a8-a49125589491"),
                            Category = grassCategory
                        },
                        new PokemonCategory()
                        {
                            PokemonId = Guid.Parse("dacce0af-f1f9-4aa7-83a8-a49125589491"),
                            Category = eartCategory
                        }
                    },
                    PokemonAbilities = new List<PokemonAbility>()
                    {
                        new PokemonAbility()
                        {
                            Ability = frontalAttack,
                            PokemonId = Guid.Parse("dacce0af-f1f9-4aa7-83a8-a49125589491")
                        },
                        new PokemonAbility()
                        {
                            Ability = photosintes,
                            PokemonId = Guid.Parse("dacce0af-f1f9-4aa7-83a8-a49125589491")
                        }
                    }
                },
            };

            _pokemonDbContext.Pokemons.AddRange(pokemons);
            _pokemonDbContext.SaveChanges();
        }

        if (!_pokemonDbContext.Users.Any(u => u.NickName == "ashKetchum"))
        {
            var user = new User()
            {
                Email = "ashKetchum@gmail.com",
                FirstName = "Ash",
                LastName = "Ketchum",
                Gender = Gender.Male,
                NickName = "ashKetchum",
                PasswordHash = _passwordHashing.HashingPassword("secretPassword"),
                Roles = Roles.User
            };
            _pokemonDbContext.Users.AddRange(user);
            _pokemonDbContext.SaveChanges();
        }
    }
}