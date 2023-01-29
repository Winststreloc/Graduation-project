﻿using Microsoft.EntityFrameworkCore;
using PokemonAPI.Interfaces;
using PokemonAPI.Models;
using PokemonAPI.Models.Enums;
using PokemonWEB.Data;
using PokemonWEB.Dto;
using PokemonWEB.Models;

namespace PokemonWEB.Repository;

public class UserRepository : IUserRepository
{
    private readonly PokemonDbContext _context;
    private readonly IPasswordHashingService _passwordHashing;
    private readonly ITokenService _tokenService;
    
    public UserRepository(PokemonDbContext context, IPasswordHashingService passwordHashing, ITokenService tokenService)
    {
        _context = context;
        _passwordHashing = passwordHashing;
        _tokenService = tokenService;
    }

    public async Task<User?> CredentialsIdentification(string email, string passwordHash)
    {
        return await _context.Users.SingleOrDefaultAsync(u => u.Email == email && u.PasswordHash == passwordHash);
    }

    public async Task<User?> GetUserByEmail(string email)
    {
        return await _context.Users.SingleOrDefaultAsync(u => u.Email == email);
    }

    public async Task<User?> GetUserById(Guid id)
    {
        return await _context.Users.SingleOrDefaultAsync(u => u.Id == id);
    }

    public async Task<User?> GetUserByNickName(string nickName)
    {
        return await _context.Users.SingleOrDefaultAsync(u => u.NickName == nickName);
    }

    public async Task<Responce?> RegisterNewUser(RegistrationView registrationView)
    {
        var user = new User()
        {
            Email = registrationView.Email,
            NickName = registrationView.NickName,
            Roles = Roles.User,
            Gender = Enum.Parse<Gender>(registrationView.Gender),
            PasswordHash = _passwordHashing.HashingPassword(registrationView.Password)
        };
        await _context.Users.AddAsync(user);
        await Save();

        var userTokens = _tokenService.GenerateTokens(user);
        
        return new Responce(){ Result = userTokens };
    }

    public async Task<bool> UserNameOrEmailExists(string userName, string email)
    {
        var existEmail = await _context.Users.AnyAsync(u => u.Email == email);
        var existUser = await _context.Users.AnyAsync(u => u.NickName == userName);
        return existEmail != false || existUser != false;
    }

    public async Task<bool> Save()
    {
        var saved = await _context.SaveChangesAsync();
        return saved > 0;
    }
}