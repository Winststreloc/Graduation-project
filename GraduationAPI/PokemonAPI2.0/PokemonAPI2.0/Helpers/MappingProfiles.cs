using System.Security.Cryptography.X509Certificates;
using AutoMapper;
using PokemonWEB.Dto;
using PokemonWEB.Models;

namespace PokemonAPI.Helpers;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Pokemon, PokemonDto>();
    }
}