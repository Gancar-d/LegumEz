using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.ValueGeneration;

namespace LegumEz.Infrastructure.Persistance.DAL.Cultures.Configuration
{
    public class CultureConfiguration : IEntityTypeConfiguration<Culture>
    {
        void IEntityTypeConfiguration<Culture>.Configure(EntityTypeBuilder<Culture> builder)
        {
            ConfigureCulture(builder);
            ConfigureConditionCroissance(builder);
            ConfigureConditionGermination(builder);
        }

        private static void ConfigureCulture(EntityTypeBuilder<Culture> builder)
        {
            builder.ToTable(nameof(Culture));

            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id)
                .ValueGeneratedOnAdd()
                .HasValueGenerator<GuidValueGenerator>()
                .IsRequired();

            builder.Property(c => c.Nom);
        }

        private static void ConfigureConditionCroissance(EntityTypeBuilder<Culture> builder)
        {
            builder.OwnsOne(c => c.ConditionCroissance, condition =>
            {
                condition.ToTable(nameof(ConditionCroissance));

                condition.HasKey(c => c.CultureId);
                
                condition.WithOwner().HasForeignKey(nameof(ConditionCroissance.CultureId));

                condition.OwnsOne(c => c.TemperatureMinimale);
                condition.OwnsOne(c => c.TemperatureOptimale);
                condition.OwnsOne(c => c.TempsDeCroissance);
            });
        }

        private static void ConfigureConditionGermination(EntityTypeBuilder<Culture> builder)
        {
            builder.OwnsOne(c => c.ConditionGermination, condition =>
            {
                condition.ToTable(nameof(ConditionGermination));

                condition.HasKey(c => c.CultureId);

                condition.WithOwner().HasForeignKey(nameof(ConditionGermination.CultureId));

                condition.OwnsOne(c => c.TemperatureMinimale);
                condition.OwnsOne(c => c.TemperatureOptimale);
                condition.OwnsOne(c => c.TempsDeLevee);
            });
        }
    }
}
