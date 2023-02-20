using PokemonAPI.Models.Enums;

namespace PokemonAPI.Models;

public class Battle
{
    public Guid Id { get; set; }
    public bool BattleEnded { get; set; }
    public Queue Queue { get; set; }
    public Guid AttackPokemon { get; set; }
    public Guid DefendingPokemon { get; set; }
}