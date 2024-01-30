using LegumEz.Application.Configuration;
using LegumEz.Application.Mapping;
using LegumEz.Application.Meteo.Configuration;
using LegumEz.Infrastructure.Configuration;
using LegumEz.Infrastructure.Persistance.Mapping;
using LegumEz.Infrastructure.Persistance.Seeder;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddAutoMapper(typeof(InfrastructureProfile), typeof(ApplicationProfile));

builder.Services.ConfigureApplication();
builder.Services.ConfigureInfrastructure(builder.Configuration);
builder.Services.ConfigureMeteoHttpClient();

using (var serviceScope = builder.Services.BuildServiceProvider().CreateScope())
{
    var seeder = serviceScope.ServiceProvider.GetRequiredService<CultureSeeder>();
    seeder.Seed();
}

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
