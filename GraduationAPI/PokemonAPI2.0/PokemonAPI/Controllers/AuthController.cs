using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PokemonAPI.Interfaces;
using PokemonAPI.Models;
using PokemonWEB.Dto;

namespace PokemonWEB.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthController : Controller
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
    public async Task<Responce?> Register(RegistrationView registrationView)
    {
        if (!ModelState.IsValid)
        {
            _responce.ErrorMessages.Add("Invalid username or password.");
            _responce.IsSuccess = false;
            return _responce;
        }

        _responce = await _userRepository.RegisterNewUser(registrationView);
        return _responce;
    }


    [HttpPost("login")]
    public async Task<Responce> Login(LogginModel logginModel)
    {
        var candidate = await _userRepository.GetUserByNickName(logginModel.NickName);

        if (candidate == null)
        {
            _responce.ErrorMessages = new List<string> { "User not found" };
            _responce.IsSuccess = false;
            return _responce;
        }

        if (_passwordHashing.VerifyHashedPassword(candidate.PasswordHash, logginModel.Password))
        {
            var userTokens = _token.GenerateTokens(candidate);
            _responce.Result = userTokens;
            return _responce;
        }

        _responce.IsSuccess = false;
        return _responce;
    }

    [Authorize]
    [HttpGet]
    public async Task<Responce> RefreshToken(string refreshToken)
    {
        if (_token.ValidateRefreshToken(refreshToken))
        {
            var userId = User.Claims.FirstOrDefault(x => x.Type == "Id").Value;
            var candidate = await _userRepository.GetUserById(Guid.Parse(userId));

            var userTokens = _token.GenerateTokens(candidate);
            _responce.Result = userTokens;
            return _responce;
        }

        _responce.IsSuccess = false;
        _responce.ErrorMessages = new List<string> { "Invalid refresh_token" };
        return _responce;
    }
}