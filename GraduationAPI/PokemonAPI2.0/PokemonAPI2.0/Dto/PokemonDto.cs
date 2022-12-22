using PokemonWEB.Models;

namespace PokemonWEB.Dto;

public class PokemonDto
{
    public int PokedexId { get; set; }
    public string Name { get; set; }
    public bool Gender { get; set; }
    public int Experience { get; set; }
}