using PokemonAPI.Models;
using PokemonWEB.Dto;
using PokemonWEB.Models;

namespace PokemonAPI.Interfaces;

public interface IUserRepository
{
    Task<User> CredentialsIdentification(string email, string password);
    Task<User?> GetUserByEmail(string email);
    Task<User?> GetUserById(Guid id);
    Task<User?> GetUserByNickName(string nickName);
    Task<Responce?> RegisterNewUser(UserDto userDto);
    Task<bool> Save();
}