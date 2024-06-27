using LegumEz.Domain.AntiCorruptionLayer;
using LegumEz.Domain.Meteo;
using LegumEz.Domain.Meteo.api;
using LegumEz.Domain.Plantation;
using LegumEz.Domain.Plantation.api;
using LegumEz.Domain.Plantation.spi;

namespace LegumEz.WebApi;

public static class webapiConfiguration
{
    public static void ConfigureWebapi(this IServiceCollection services)
    {
        services.ConfigureServices();
    }

    private static void ConfigureServices(this IServiceCollection services)
    {
        services.AddScoped<IOptimizePlantation, PlantationOptimizer>();
        services.AddScoped<IAccessCulture, CultureAccessor>();
        services.AddScoped<IGetPredictionMeteo, GetPredictionMeteoForPlantation>();
        services.AddScoped<IMeteoForecast, MeteoForecaster>();
    }
}