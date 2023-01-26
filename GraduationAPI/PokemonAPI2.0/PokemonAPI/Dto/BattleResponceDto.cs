using PokemonWEB.Models;

namespace PokemonAPI.Dto;

public class BattleResponceDto
{
    public Pokemon Pokemon1 { get; set; }
    public Pokemon Pokemon2 { get; set; }
    public string Description { get; set; }
    public bool BattleEnded { get; set; }
}