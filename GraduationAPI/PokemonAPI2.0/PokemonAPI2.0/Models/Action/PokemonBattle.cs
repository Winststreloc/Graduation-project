using PokemonWEB.Models.Action;

namespace PokemonWEB.Models.Battle;

public class PokemonBattle
{
    public Guid Id { get; set; }
    public Pokemon pokemonUser { get; set; }
    public Pokemon pokemonEnemy { get; set; }
}