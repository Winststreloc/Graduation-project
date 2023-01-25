using Microsoft.Extensions.DependencyInjection;
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
        service.AddScoped<ILocalBattleService, LocalBattleService>();        
        service.AddScoped<IBattleRepository, BattleRepository>();        

    }
}