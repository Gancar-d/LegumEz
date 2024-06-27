namespace LegumEz.Infrastructure.Persistance.DAL.Cultures
{
    public class ConditionGermination
    {
        public Guid CultureId { get; set; }
        public Temperature TemperatureMinimale { get; set; }
        public Temperature TemperatureOptimale { get; set; }
        public Temps TempsDeLevee { get; set; }
    }
}
