namespace PokemonWEB.Models;

public class PokemonOwner
{
    public Guid PokemonId { get; set; }
    public Guid UserId { get; set; }
    public Pokemon Pokemon { get; set; }
    public User User { get; set; }
}