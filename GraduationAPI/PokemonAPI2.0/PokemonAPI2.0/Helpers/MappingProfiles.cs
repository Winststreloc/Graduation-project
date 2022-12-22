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

        CreateMap<Pokedex, PokedexDto>();
        CreateMap<PokedexDto, Pokedex>();
        
        CreateMap<Pokedex, Task<PokedexDto>>();
        CreateMap<Task<PokedexDto>, Pokedex>();
    }
}