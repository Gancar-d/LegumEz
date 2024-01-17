using LegumEz.Infrastructure.Options;
using LegumEz.Infrastructure.Persistance.DAL.Cultures;
using LegumEz.Infrastructure.Persistance.DAL.Cultures.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace LegumEz.Infrastructure.Persistance.Configuration
{
    public class ApplicationDbContext : DbContext
    {
        private readonly ConnectionStrings _connectionStrings;

        public DbSet<Culture> Cultures { get; set; }

        public ApplicationDbContext(IOptions<ConnectionStrings> connectionStrings)
        {
            _connectionStrings = connectionStrings.Value;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionStrings.LegumEzDb);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CultureConfiguration());
        }
    }
}
