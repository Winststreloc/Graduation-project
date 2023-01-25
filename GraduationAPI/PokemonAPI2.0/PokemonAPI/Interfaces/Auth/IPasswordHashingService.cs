namespace PokemonAPI.Interfaces;

public interface IPasswordHashingService
{
    string HashingPassword(string password);
    bool VerifyHashedPassword(string hashedPassword, string password);
}