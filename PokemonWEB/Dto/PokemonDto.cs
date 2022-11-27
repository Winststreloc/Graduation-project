using PokemonWEB.Models;

namespace PokemonWEB.Dto;

public class PokemonDto
{
    public int PokedexId { get; set; }
    public string Name { get; set; }
    public int Weight { get; set; }
    public int Height { get; set; }
    public int Experiance { get; set; }
}