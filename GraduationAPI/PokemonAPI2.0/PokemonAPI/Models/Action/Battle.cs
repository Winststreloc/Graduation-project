using PokemonWEB.Models;

namespace PokemonAPI2._0.Models.Action;

public class Battle
{
    public Guid Id { get; set; }
    public Pokemon PokemonUser { get; set; }
    public Pokemon PokemonEnemy { get; set; }
}