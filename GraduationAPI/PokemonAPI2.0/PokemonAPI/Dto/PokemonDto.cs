using PokemonWEB.Models;

namespace PokemonWEB.Dto;

public class PokemonDto
{
    public int PokemonRecordId { get; set; }
    public string Name { get; set; }
    public bool Gender { get; set; }
    public int Experience { get; set; }
    public int CurrentHealth { get; set; }
    public int CurrentDamage { get; set; }
    public int CurrentDefence { get; set; }
}