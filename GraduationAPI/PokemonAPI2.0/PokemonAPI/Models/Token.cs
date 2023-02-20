using PokemonAPI.Models.Enums;

namespace PokemonAPI.Models;

public class Token
{
    public string AccessToken { get; set; }
    public string RefreshToken { get; set; }
    public string NickName { get; set; }
    public Guid UserId { get; set; }
    public Roles UserRoles { get; set; }
}