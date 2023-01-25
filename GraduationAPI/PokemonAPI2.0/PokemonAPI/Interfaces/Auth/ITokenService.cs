using System.Security.Claims;
using PokemonAPI.Models;
using PokemonWEB.Models;

namespace PokemonAPI.Interfaces;

public interface ITokenService
{
    Token GenerateTokens(User candidateForTokens);
    IEnumerable<Claim> GetUserClaims(User candidateForTokens);
    string GenerateAccessToken(IEnumerable<Claim> userClaims);
    string GenerateRefreshToken(IEnumerable<Claim> userClaims);
    bool ValidateRefreshToken(string refreshToken);
}