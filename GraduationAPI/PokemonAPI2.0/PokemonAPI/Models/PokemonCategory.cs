namespace PokemonWEB.Models;

public class PokemonCategory
{
    public Guid PokemonId { get; set; }
    public Guid CategoryId { get; set; }
    public Pokemon Pokemon { get; set; }
    public Category Category { get; set; }
}