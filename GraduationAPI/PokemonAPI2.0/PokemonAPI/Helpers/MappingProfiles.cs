using AutoMapper;
using PokemonWEB.Dto;
using PokemonWEB.Models;

namespace PokemonAPI.Helpers;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<User, UserDto>().ReverseMap();
        CreateMap<Pokemon, PokemonRecord>().ReverseMap();
    }
}