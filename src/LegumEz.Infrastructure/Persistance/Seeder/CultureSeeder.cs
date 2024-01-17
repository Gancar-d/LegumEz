using LegumEz.Infrastructure.Options;
using LegumEz.Infrastructure.Persistance.Configuration;
using LegumEz.Infrastructure.Persistance.DAL.Cultures;
using Microsoft.Extensions.Options;
using System.Text.Json;

namespace LegumEz.Infrastructure.Persistance.Seeder
{
    public class CultureSeeder
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly SeedFile _seedFile;

        public CultureSeeder(ApplicationDbContext dbContext, IOptions<SeedFile> seedFileOptions)
        {
            _dbContext = dbContext;
            _seedFile = seedFileOptions.Value;

            _dbContext.Database.EnsureCreated();
        }

        public void Seed()
        {
            if (_dbContext.Cultures.Any())
            {
                return;
            }

            var jsonData = System.IO.File.ReadAllText(_seedFile.Path);
            var cultures = JsonSerializer.Deserialize<List<Culture>>(jsonData);

            _dbContext.Cultures.AddRange(cultures);
            _dbContext.SaveChanges();
        }
    }
}
