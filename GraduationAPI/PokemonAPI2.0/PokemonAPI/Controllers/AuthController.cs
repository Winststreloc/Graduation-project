﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PokemonAPI.Interfaces;
using PokemonAPI.Models;
using PokemonWEB.Dto;

namespace PokemonWEB.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private Responce? _responce;
    private readonly IMapper _mapper;
    private readonly IUserRepository _userRepository;
    private readonly ITokenService _token;
    private readonly IPasswordHashingService _passwordHashing;


    public AuthController(IMapper mapper, IUserRepository userRepository, IPasswordHashingService passwordHashing,
        ITokenService token)
    {
        _mapper = mapper;
        _userRepository = userRepository;
        _passwordHashing = passwordHashing;
        _token = token;
        _responce = new Responce();
    }

    [HttpPost("register")]
    public async Task<Responce?> Register([FromBody] UserDto userDto)
    {
        if (!ModelState.IsValid)
        {
            _responce.ErrorMessages.Add("Invalid username or password.");
            _responce.IsSuccess = false;
            return _responce;
        }

        _responce = await _userRepository.RegisterNewUser(userDto);
        return _responce;
    }

    [HttpPost("login")]
    public async Task<Responce> Login([FromQuery] string nickName, [FromQuery] string password)
    {
        var candidate = await _userRepository.GetUserByNickName(nickName);

        if (candidate == null)
        {
            _responce.ErrorMessages = new List<string> { "User not found" };
            _responce.IsSuccess = false;
            return _responce;
        }

        if (_passwordHashing.HashingPassword(password) == candidate.PasswordHash)
        {
            var userTokens = _token.GenerateTokens(candidate);
            _responce.Result = userTokens;
            return _responce;
        }

        _responce.IsSuccess = false;
        return _responce;
    }
}