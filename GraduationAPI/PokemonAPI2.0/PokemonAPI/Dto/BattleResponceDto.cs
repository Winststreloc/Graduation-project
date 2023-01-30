using PokemonWEB.Models;

namespace PokemonAPI.Dto;

public class BattleResponceDto
{
    public Pokemon? AtackPokemon { get; set; }
    public Pokemon? DefendingPokemon { get; set; }
    public string Description { get; set; }
    public bool BattleEnded { get; set; }
}