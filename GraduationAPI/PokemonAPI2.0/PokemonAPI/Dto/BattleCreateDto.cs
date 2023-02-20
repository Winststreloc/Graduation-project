namespace PokemonAPI.Dto;

public class BattleCreateDto
{
    public Guid AttackPokemon { get; set; }
    public Guid DefendingPokemon { get; set; }
}