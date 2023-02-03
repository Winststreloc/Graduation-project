using PokemonWEB.Models;
using PokemonWEB.Models.Action;

namespace PokemonAPI.Dto;

public class PokemonAbilityCategoryDto
{
    public Pokemon Pokemon { get; set; }
    public ICollection<Ability> Abilities { get; set; }
    public ICollection<Category> Categories { get; set; }
}