namespace PokemonAPI.Models;

public class Responce
{
    public bool IsSuccess { get; set; } = true;
    public object Result { get; set; }
    public List<string> ErrorMessages { get; set; }
}