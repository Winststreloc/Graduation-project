namespace PokemonAPI.Models;

public class ResponceAuthDto
{
    public bool IsSuccess { get; set; } = true;
    public object Result { get; set; }
    public List<string> ErrorMessages { get; set; }
}