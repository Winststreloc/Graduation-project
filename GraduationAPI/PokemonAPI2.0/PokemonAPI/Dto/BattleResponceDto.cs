using PokemonWEB.Models;

namespace PokemonAPI.Dto;

public class BattleResponceDto
{
    public Pokemon? AtackPokemon { get; set; }
    public Pokemon? DefendingPokemon { get; set; }
    public string DescriptionFirstPokemon { get; set; }
    public string? DescriptionSecondPokemon { get; set; }
    public bool BattleEnded { get; set; }
}