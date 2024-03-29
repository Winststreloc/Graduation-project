﻿using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PokemonAPI.Interfaces;
using PokemonWEB.Models;

namespace PokemonWEB.Controllers;

[ApiController]
[Route("[controller]")]
[Authorize]
public class UserController : Controller
{
    private readonly IUserRepository _repository;
    private readonly IMapper _mapper;

    public UserController(IUserRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    [HttpGet("get-user-by-nickname")]
    public async Task<IActionResult> GetUserByName(string nickname)
    {
        var user = await _repository.GetUserByNickName(nickname);
        return Ok(user);
    }

    [HttpGet("get-user-byemail")]
    public async Task<IActionResult> GetUserByEmail(string email)
    {
        var user = await _repository.GetUserByEmail(email);
        return Ok(user);
    }
}