using Microsoft.Extensions.DependencyInjection;
using PokemonAPI.Interfaces;
using PokemonAPI.Service;
using PokemonWEB.Interfaces;
using PokemonWEB.Repository;

namespace PokemonAPI;

public static class DIExtention
{
    public static void ConfigureServices(this IServiceCollection service)
    {
        service.AddScoped<IPokemonRepository, PokemonRepository>();
        service.AddScoped<ICategoryRepository, CategoryRepository>();
        service.AddScoped<IPokedexRepository, PokedexRepository>();
        service.AddScoped<IBattleService, BattleService>();        
        service.AddScoped<IBattleRepository, BattleRepository>();

        service.AddScoped<IUserRepository, UserRepository>();
        service.AddScoped<IPasswordHashingService, PasswordHashingService>();
        service.AddScoped<ITokenService, TokenService>();


    }
}