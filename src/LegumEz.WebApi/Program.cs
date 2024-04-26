using System.Configuration;
using LegumEz.Application.Configuration;
using LegumEz.Application.Mapping;
using LegumEz.Application.Meteo.Configuration;
using LegumEz.Infrastructure.Configuration;
using LegumEz.Infrastructure.Persistance.Mapping;
using LegumEz.Infrastructure.Persistance.Seeder;
using LegumEz.WebApi.Middlewares;
using Serilog;
using Serilog.Events;
using Serilog.Sinks.Elasticsearch;

try
{
    var loggerConfiguration = new LoggerConfiguration();
    ConfigureLogger(loggerConfiguration);
    Log.Logger = loggerConfiguration.CreateBootstrapLogger();

    Log.Information("Starting web application");
    var builder = WebApplication.CreateBuilder(args);

    ConfigureSerilog(builder);
    
    builder.Services.AddAutoMapper(typeof(InfrastructureProfile), typeof(ApplicationProfile));
    builder.Services.ConfigureApplication();
    builder.Services.ConfigureInfrastructure(builder.Configuration);
    builder.Services.ConfigureMeteoHttpClient();

    using (var serviceScope = builder.Services.BuildServiceProvider().CreateScope())
    {
        var seeder = serviceScope.ServiceProvider.GetRequiredService<CultureSeeder>();
        seeder.Seed();
    }

    builder.Services.AddControllers();
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    var app = builder.Build();
    app.UseSerilogRequestLogging();

    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
        app.UseDeveloperExceptionPage();
    }

    app.UseMiddleware<ExceptionMiddleware>();
    app.UseHttpsRedirection();
    app.UseAuthorization();
    app.MapControllers();

    app.Run();
}
catch (Exception ex)
{
    Log.Fatal(ex, "Application terminated unexpected");
}
finally
{
    Log.CloseAndFlush();
}

return;

void ConfigureSerilog(WebApplicationBuilder webApplicationBuilder)
{
    webApplicationBuilder.Services.AddLogging(loggingBuilder =>
        loggingBuilder.AddSerilog(dispose: true));

    webApplicationBuilder.Host.UseSerilog((context, services, configuration) =>
    {
        var elasticUri = GetElasticUri(context);
        var elasticApiKey = GetElasticApiKey(context);

        ConfigureLogger(configuration);
        configuration
            .ReadFrom.Configuration(context.Configuration)
            .ReadFrom.Services(services)
            .WriteTo.Elasticsearch(
                new ElasticsearchSinkOptions(
                    new Uri(elasticUri))
                {
                    IndexFormat = "log-legumez-dev",
                    AutoRegisterTemplate = true,
                    NumberOfShards = 2,
                    NumberOfReplicas = 1,
                    EmitEventFailure = EmitEventFailureHandling.WriteToSelfLog,
                    MinimumLogEventLevel = LogEventLevel.Information,
                    ApiKey = elasticApiKey
                });
    }, true);
}

void ConfigureLogger(LoggerConfiguration loggerConfiguration)
{
    loggerConfiguration
        .MinimumLevel.Override("Microsoft.AspNetCore.Hosting", LogEventLevel.Warning)
        .MinimumLevel.Override("Microsoft.AspNetCore.Mvc", LogEventLevel.Warning)
        .MinimumLevel.Override("Microsoft.AspNetCore.Routing", LogEventLevel.Warning)
        .Enrich.WithHttpRequestId()
        .Enrich.WithHttpRequestClientHostIP()
        .Enrich.WithHttpRequestNumber()
        .Enrich.WithUserName()
        .WriteTo.Console(outputTemplate: "{Timestamp} [{Level}] {Properties:j} - {Message}{NewLine}{Exception}");

#if DEBUG

    // loggerConfiguration
    //     .MinimumLevel.Debug();

#endif
}

string GetElasticUri(HostBuilderContext hostBuilderContext)
{
    var uri = hostBuilderContext.Configuration.GetValue<string>("ElasticConfig:Uri");
    if (uri == null)
    {
        throw new ConfigurationErrorsException("Setting \"ElasticConfig:Uri\" not found in appsettings.json");
    }

    return uri;
}

string GetElasticApiKey(HostBuilderContext hostBuilderContext)
{
    var apiKey = hostBuilderContext.Configuration.GetValue<string>("ElasticConfig:ApiKey");
    if (apiKey == null)
    {
        throw new ConfigurationErrorsException("Setting \"ElasticConfig:Uri\" not found in appsettings.json");
    }

    return apiKey;
}