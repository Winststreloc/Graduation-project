﻿using PokemonAPI.Models;
using PokemonWEB.Dto;
using PokemonWEB.Models;

namespace PokemonAPI.Interfaces;

public interface IUserRepository
{
    Task<User> CredentialsIdentification(string email, string password);
    Task<User?> GetUserByEmail(string email);
    Task<User?> GetUserById(Guid id);
    Task<User?> GetUserByNickName(string nickName);
    Task<ResponceAuthDto?> RegisterNewUser(RegistrationModelDto registrationModelDto);
    Task<bool> UserNameOrEmailExists(string userName, string email);
    Task<bool> Save();
}