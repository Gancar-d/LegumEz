using LegumEz.Domain.Cultures;
using LegumEz.Infrastructure.Options;
using LegumEz.Infrastructure.Persistance.Repositories;
using LegumEz.Infrastructure.Persistance.Seeder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LegumEz.Infrastructure.Persistance.Configuration
{
    public static class InfrastructureConfiguration
    {
        public static void ConfigureInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.ConfigureOptions(configuration);
            services.ConfigureRepositories();
            services.ConfigureDbContexts();
            services.ConfigureServices();
        }

        private static void ConfigureServices(this IServiceCollection services)
        {
            services.AddScoped<CultureSeeder>();
        }

        private static void ConfigureDbContexts(this IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>();
        }

        private static void ConfigureRepositories(this IServiceCollection services)
        {
            services.AddScoped<ICultureRepository, CultureRepository>();
        }

        private static void ConfigureOptions(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<ConnectionStrings>(configuration.GetSection(nameof(ConnectionStrings)));
            services.Configure<SeedFile>(configuration.GetSection(nameof(SeedFile)));
        }
    }
}
