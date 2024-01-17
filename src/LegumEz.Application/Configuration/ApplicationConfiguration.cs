using LegumEz.Application.Cultures;
using LegumEz.Application.Mapping;
using Microsoft.Extensions.DependencyInjection;

namespace LegumEz.Application.Configuration
{
    public static class ApplicationConfiguration
    {
        public static void ConfigureApplication(this IServiceCollection services)
        {
            services.ConfigureServices();
            services.ConfigureMapping();
        }

        private static void ConfigureServices(this IServiceCollection services)
        {
            services.AddScoped<ICultureService, CultureService>();
        }

        private static void ConfigureMapping(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(ApplicationProfile));
        }
    }
}
