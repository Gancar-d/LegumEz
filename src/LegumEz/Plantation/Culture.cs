namespace LegumEz.Domain.Plantation
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

        public Mois GetMoisOptimalDePlantation(IEnumerable<PredictionMeteo> predictionsMeteos)
        {
            var predictionsMeteosByMonth = predictionsMeteos.GroupBy(x => x.Jour.Month);
            
            var moisEtTemperatureProche = predictionsMeteosByMonth.Select(group =>
            {
                int mois = group.Key;
                double temperatureMoyenneProche = group
                    .Select(p => Math.Abs((p.TemperatureMoyenne - ConditionGermination.TemperatureOptimale).Valeur))
                    .Min();

                return new { Mois = mois, TemperatureProche = temperatureMoyenneProche };
            });

            var moisOptimal = moisEtTemperatureProche.OrderBy(x => x.TemperatureProche).First().Mois;
            
            return (Mois)moisOptimal;
        }
    }
}