using PokemonAPI.Models.Enums;

namespace PokemonAPI.Models;

public class Battle
{
    public Guid Id { get; set; }
    public Guid Pokemon1 { get; set; }
    public Guid Pokemon2 { get; set; }
    public bool BattleEnded { get; set; }
    public Queue Queue { get; set; }
}