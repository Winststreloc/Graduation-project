using AutoMapper;
using PokemonWEB.Dto;
using PokemonWEB.Models;

namespace PokemonAPI.Helpers;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Pokemon, PokemonDto>();
        CreateMap<PokemonDto, Pokemon>();
        CreateMap<Category, CategoryDto>();
        CreateMap<CategoryDto, Category>();
    }
}