namespace LegumEz.Infrastructure.Persistance.DAL.Cultures
{
    public record ConditionCroissance
    {
        public Guid CultureId { get; set; }
        public Temperature TemperatureMinimale { get; set; }
        public Temperature TemperatureOptimale { get; set; }
        public Temps TempsDeCroissance { get; set; }
    }
}
