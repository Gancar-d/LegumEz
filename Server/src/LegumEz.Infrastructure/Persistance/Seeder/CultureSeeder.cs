using LegumEz.Infrastructure.Options;
using LegumEz.Infrastructure.Persistance.Configuration;
using LegumEz.Infrastructure.Persistance.DAL.Cultures;
using Microsoft.Extensions.Options;
using System.Text.Json;
using Microsoft.Extensions.Logging;

namespace LegumEz.Infrastructure.Persistance.Seeder
{
    public class CultureSeeder
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly SeedFile _seedFile;
        private readonly ILogger<CultureSeeder> _logger;

        public CultureSeeder(ApplicationDbContext dbContext, IOptions<SeedFile> seedFileOptions, ILogger<CultureSeeder> logger)
        {
            _dbContext = dbContext;
            _seedFile = seedFileOptions.Value;
            _logger = logger;

            _dbContext.Database.EnsureCreated();
        }

        public void Seed()
        {
            if (_dbContext.Cultures.Any())
            {
                _logger.LogInformation("Banque de donnée de culture déjà remplie. Rien à faire.");
                return;
            }

            _logger.LogInformation("Banque de donnée de culture innexistante. Population de la base de donnée");
            _logger.LogDebug("Population depuis le fichier JSON {SeedFilePath}", _seedFile.Path);
            
            var jsonData = System.IO.File.ReadAllText(_seedFile.Path);
            var cultures = JsonSerializer.Deserialize<List<Culture>>(jsonData);

            try
            {
                _dbContext.Cultures.AddRange(cultures);
                _dbContext.SaveChanges();
            }
            catch (Exception e)
            {
                _logger.LogCritical(e, "Une erreur est survenue lors de la population de la banque de donnée de cultures.");
                throw;
            }
            
            _logger.LogInformation("Banque de donnée de culture correctement créée.");
        }
    }
}
