using PokemonAPI.Interfaces;
using PokemonAPI.Interfaces.IRepository;
using PokemonAPI.Middleware;
using PokemonAPI.Service;
using PokemonWEB.Interfaces;
using PokemonWEB.Repository;

namespace PokemonAPI;

public static class DIExtention
{
    public static void ConfigureServices(this IServiceCollection service)
    {
        service.AddScoped<IPokemonRepository, PokemonRepository>();
        service.AddScoped<IPokemonService, PokemonService>();
        service.AddScoped<ICategoryRepository, CategoryRepository>();
        service.AddScoped<IAbilityRepository, AbilityRepository>();
        service.AddScoped<IPokedexRepository, PokedexRepository>();
        service.AddScoped<IBattleRepository, BattleRepository>();
        service.AddScoped<IBattleService, BattleService>();

        service.AddScoped<IUserRepository, UserRepository>();
        service.AddScoped<IPasswordHashingService, PasswordHashingService>();
        service.AddScoped<ITokenService, TokenService>();
        service.AddScoped<ExceptionMiddleware>();
    }
}