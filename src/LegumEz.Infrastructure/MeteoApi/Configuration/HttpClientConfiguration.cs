using Microsoft.Extensions.DependencyInjection;

namespace LegumEz.Application.Meteo.Configuration;

public static class HttpClientConfiguration
{
    public static void ConfigureMeteoHttpClient(this IServiceCollection services)
    {
        services.AddHttpClient("MeteoApi", client =>
        {
            client.BaseAddress = new Uri("https://weather.visualcrossing.com/");
        });
    }
}