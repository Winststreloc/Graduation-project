namespace PokemonWEB.Models;

public class PokemonOwner
{
    public Guid PokemonId { get; set; }
    public Guid OwnerId { get; set; }
    public Pokemon Pokemon { get; set; }
    public Owner Owner { get; set; }
}