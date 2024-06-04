using LegumEz.Domain.Plantation;
using LegumEz.Domain.Plantation.api;

namespace LegumEz.WebApi;

public static class webapiConfiguration
{
    public static void ConfigureWebapi(this IServiceCollection services)
    {
        services.ConfigureServices();
    }

    private static void ConfigureServices(this IServiceCollection services)
    {
        services.AddScoped<OptimizePlantation, PlantationOptimizer>();
    }
}