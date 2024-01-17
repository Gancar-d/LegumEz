using LegumEz.Infrastructure.Persistance.Configuration;
using Microsoft.EntityFrameworkCore;

namespace LegumEz.WebApi.Tests.Builders.DbContext
{
    public class DbContextBuilder
    {
        private DbContextOptions<ApplicationDbContext> _dbContextOptions;

        public DbContextBuilder()
        {
            _dbContextOptions = new DbContextOptions<ApplicationDbContext>();
        }

        public DbContextBuilder WithUsingInMemoryDatabase()
        {
            _dbContextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "LegumEzDb")
                .Options;

            return this;
        }

        public ApplicationDbContext Build()
        {
            return new ApplicationDbContext(_dbContextOptions);
        }
    }
}
