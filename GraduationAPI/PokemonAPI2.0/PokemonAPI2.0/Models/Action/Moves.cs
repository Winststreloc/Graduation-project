using PokemonAPI;

namespace PokemonWEB.Models.Action;

public class Moves
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public int Damage { get; set; }
    public int Healing { get; set; }
    public ICollection<PokemonAbility> PokemonAbilities { get; set; }
}