using PokemonWEB.Models;

namespace PokemonAPI.Dto;

public class BattleResponceDto
{
    public Pokemon? AtackPokemon { get; set; }
    public Pokemon? DefendingPokemon { get; set; }
    public string NameAbilityFirstPokemon { get; set; }
    public string DescriptionFirstPokemon { get; set; }
    public int DamageFirstPokemon { get; set; }
    public string? NameAbilitySecondPokemon { get; set; }
    public string? DescriptionSecondPokemon { get; set; }
    public int DamageSecondPokemon { get; set; }
    public bool BattleEnded { get; set; }
}