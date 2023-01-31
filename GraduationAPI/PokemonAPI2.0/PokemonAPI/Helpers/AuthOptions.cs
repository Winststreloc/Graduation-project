using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace PokemonAPI;

public class AuthOptions
{
    public const string ISSUER = "PokemonAPI";
    public const string AUDIENCE = "Pokemon-Api";
    private const string KEY = "mysupersecret_secretkey!123";
    public static SymmetricSecurityKey GetSymmetricSecurityKey()
    {
        return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(KEY));
    }
}