using LegumEz.Domain.Entity;

namespace LegumEz.Infrastructure.Persistance.DAL.Cultures
{
    public class Culture
    {
        public Guid Id { get; set; }
        public string Nom { get; set; }
        public ConditionGermination ConditionGermination { get; set; }
        public ConditionCroissance ConditionCroissance { get; set; }
    }
}
