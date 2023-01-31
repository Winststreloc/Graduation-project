using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using PokemonAPI.Interfaces;
using PokemonAPI.Models;
using PokemonAPI.Models.Enums;
using PokemonWEB.Models;

namespace PokemonAPI.Service;

public class TokenService : ITokenService
{
    private const int _accessTokenExpiresMinutes = 60;
    private const int _refreshTokenExpiresDays = 30;

    public Token GenerateTokens(User candidateForTokens)
    {
        var claims = GetUserClaims(candidateForTokens);
        var accessToken = GenerateAccessToken(claims);
        var refreshToken = GenerateRefreshToken(claims);

        var token = new Token()
        {
            UserId = candidateForTokens.Id,
            AccessToken = accessToken,
            RefreshToken = refreshToken,
            NickName = candidateForTokens.NickName,
            UserRoles = candidateForTokens.Roles
        };

        return token;
    }

    public IEnumerable<Claim> GetUserClaims(User candidateForTokens)
    {
        var claims = new List<Claim>();
        claims.Add(new Claim("Id", candidateForTokens.Id.ToString()));
        claims.Add(new Claim("NickName", candidateForTokens.NickName));
        claims.Add(new Claim(ClaimTypes.Role, candidateForTokens.Roles.ToString()));
        return claims;
        // return new List<Claim>()
        // {
        //     new Claim("Id", candidateForTokens.Id.ToString()),
        //     new Claim( "Role", candidateForTokens.Roles.ToString()),
        //     new Claim("NickName", candidateForTokens.NickName),
        // };
    }

    public string GenerateAccessToken(IEnumerable<Claim> userClaims)
    {
        var jwt = new JwtSecurityToken(
            issuer: AuthOptions.ISSUER,
            audience: AuthOptions.AUDIENCE,
            claims: userClaims,
            expires: DateTime.UtcNow.Add(TimeSpan.FromMinutes(_accessTokenExpiresMinutes)),
            signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(),
                SecurityAlgorithms.HmacSha256));

        return new JwtSecurityTokenHandler().WriteToken(jwt);
    }

    public string GenerateRefreshToken(IEnumerable<Claim> userClaims)
    {
        var id = userClaims.Where(claim => claim.Type == "Id");
        var jwt = new JwtSecurityToken(
            issuer: AuthOptions.ISSUER,
            audience: AuthOptions.AUDIENCE,
            claims: userClaims.Where(claim => claim.Type == "Id"),
            expires: DateTime.UtcNow.Add(TimeSpan.FromDays(_refreshTokenExpiresDays)),
            signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(),
                SecurityAlgorithms.HmacSha256));

        return new JwtSecurityTokenHandler().WriteToken(jwt);
    }

    public bool ValidateRefreshToken(string refreshToken)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var validationParameters = new TokenValidationParameters()
        {
            ValidateLifetime = false, // Because there is no expiration in the generated token
            ValidateAudience = false, // Because there is no audiance in the generated token
            ValidateIssuer = false,
            ValidIssuer = AuthOptions.ISSUER,
            IssuerSigningKey = AuthOptions.GetSymmetricSecurityKey(),
            ValidAudience = AuthOptions.AUDIENCE,
        };


        SecurityToken validatedToken;

        try
        {
            IPrincipal principal = tokenHandler.ValidateToken(refreshToken, validationParameters, out validatedToken);
        }
        catch (SecurityTokenSignatureKeyNotFoundException)
        {
            return false;
        }

        return true;
    }
}