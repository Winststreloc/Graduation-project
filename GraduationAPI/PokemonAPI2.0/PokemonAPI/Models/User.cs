using PokemonAPI.Models.Enums;

namespace PokemonWEB.Models;

public class User
{
    public Guid Id { get; set; }
    public string NickName { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Email { get; set; }
    public string PasswordHash { get; set; }
    public Gender? Gender { get; set; }
    public Roles Roles { get; set; }
    
    public ICollection<Pokemon> Pokemons { get; set; }
}