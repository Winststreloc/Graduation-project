using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace PokemonAPI;

public class AuthOptions
{
    public const string ISSUER = "PokemonAPI"; // издатель токена
    public const string AUDIENCE = "Pokemon-Api"; // потребитель токена
    const string KEY = "mysupersecret_secretkey!123";   // ключ для шифрации
    public static SymmetricSecurityKey GetSymmetricSecurityKey()
    {
        return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(KEY));
    }
}