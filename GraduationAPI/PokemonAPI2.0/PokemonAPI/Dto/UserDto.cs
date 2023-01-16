﻿using PokemonAPI.Models.Enums;

namespace PokemonWEB.Dto;

public class UserDto
{
    public string NickName { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    
    public string Gender { get; set; }
}