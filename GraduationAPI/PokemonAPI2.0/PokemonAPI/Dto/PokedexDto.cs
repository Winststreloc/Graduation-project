namespace PokemonWEB.Dto;

public class PokedexDto
{
    public int PokedexId { get; set; }
    public string Name { get; set; }
    public int PokemonPower { get; set; }
    public int BaseDamage { get; set; }
    public int BaseHP { get; set; }
    public int BaseDefense { get; set; }
    public double Weight { get; set; }
    public double Height { get; set; }
    public string ImageURL { get; set; }
}