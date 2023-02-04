using PokemonWEB.Models;

namespace PokemonAPI.Models;

public class PokemonRecordCategory
{
    public PokemonRecord PokemonRecord { get; set; }
    public Category Category { get; set; }
    public int CategoryId { get; set; }
    public int PokemonRecordId { get; set; }
}