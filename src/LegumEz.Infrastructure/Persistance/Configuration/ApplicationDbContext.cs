using LegumEz.Infrastructure.Options;
using LegumEz.Infrastructure.Persistance.DAL.Cultures;
using LegumEz.Infrastructure.Persistance.DAL.Cultures.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace LegumEz.Infrastructure.Persistance.Configuration
{
    public class ApplicationDbContext : DbContext
    {

        public DbSet<Culture> Cultures { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CultureConfiguration());
        }
    }
}
