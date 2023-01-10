using AutoMapper;
using PokemonWEB.Dto;
using PokemonWEB.Models;

namespace PokemonAPI.Helpers;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Pokemon, PokemonDto>().ReverseMap();
        CreateMap<Category, CategoryDto>().ReverseMap();
        CreateMap<Pokedex, PokedexDto>().ReverseMap();

        CreateMap<Pokedex, Task<PokedexDto>>();
        CreateMap<Task<PokedexDto>, Pokedex>();
    }
}