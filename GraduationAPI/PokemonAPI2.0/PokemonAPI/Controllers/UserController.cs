using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PokemonAPI.Interfaces;
using PokemonWEB.Models;

namespace PokemonWEB.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : Controller
{
    private readonly IUserRepository _repository;
    private readonly IMapper _mapper;

    public UserController(IUserRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    [HttpGet("get-User-ByNickName")]
    public async Task<IActionResult> GetUserByName(string nickname)
    {
        var user = await _repository.GetUserByNickName(nickname);
        return Ok(user);
    }

    [HttpGet("get-User-ByEmail")]
    public async Task<IActionResult> GetUserByEmail(string email)
    {
        var user = await _repository.GetUserByEmail(email);
        return Ok(user);
    }
}