using PokemonWEB.Models;

namespace PokemonAPI2._0.Models.Action;

public class Battle
{
    public Guid PokemonUserId { get; set; }
    public Guid PokemonEnemyId { get; set; }
}