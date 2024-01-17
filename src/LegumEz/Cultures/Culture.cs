namespace LegumEz.Domain.Cultures
{
    public record Culture
    {
        public Culture(Guid id, string nom, ConditionGermination conditionGermination, ConditionCroissance conditionCroissance)
        {
            Id = id;
            Nom = string.IsNullOrWhiteSpace(nom) ? throw new ArgumentException(nameof(nom), "Le nom ne peut pas être vide") : nom;
            ConditionGermination = conditionGermination ?? throw new ArgumentNullException(nameof(conditionGermination), "La condition de germination est requise");
            ConditionCroissance = conditionCroissance ?? throw new ArgumentNullException(nameof(conditionCroissance), "La condition de croissance est requise");
        }
        public Guid Id { get; }
        public string Nom { get; }
        public ConditionGermination ConditionGermination { get; }
        public ConditionCroissance ConditionCroissance { get; }
    }
}