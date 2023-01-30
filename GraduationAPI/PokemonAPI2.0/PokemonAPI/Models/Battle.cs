using System.ComponentModel.DataAnnotations.Schema;
using PokemonAPI.Models.Enums;
using PokemonWEB.Models;

namespace PokemonAPI.Models;

public class Battle
{
    public Guid Id { get; set; }
    public bool BattleEnded { get; set; }
    public Queue Queue { get; set; }
    public ICollection<Pokemon>? Pokemons { get; set; }
}