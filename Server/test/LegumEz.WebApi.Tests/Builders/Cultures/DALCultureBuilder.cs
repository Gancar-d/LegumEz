
using LegumEz.Infrastructure.Persistance.DAL.Cultures;

namespace LegumEz.WebApi.Tests.Builders.Cultures
{
    internal class DALCultureBuilder
    {
        private Guid _id;
        private string _name;
        private ConditionGermination _conditionGermination;
        private ConditionCroissance _conditionCroissance;

        public DALCultureBuilder WithRandomId()
        {
            _id = Guid.NewGuid();

            return this;
        }

        public DALCultureBuilder WithId(Guid id)
        {
            _id = id;

            return this;
        }
        
        public DALCultureBuilder WithName(string name)
        {
            _name = name;

            return this;
        }

        public DALCultureBuilder WithDefaultValidConditionGermination()
        {
            var temperatureMinimale = new Temperature(10, UniteTemperature.Celsius);
            var temperatureOptimale = new Temperature(20, UniteTemperature.Celsius);
            var tempsDeLevee = new Temps() { Valeur = 1, Unite = UniteDeTemps.Jours };

            _conditionGermination = new ConditionGermination()
            {
                TemperatureMinimale = temperatureMinimale,
                TemperatureOptimale = temperatureOptimale,
                TempsDeLevee = tempsDeLevee
            };

            return this;
        }
        
        public DALCultureBuilder WithDefaultValidConditionCroissance()
        {
            var temperatureMinimale = new Temperature(10, UniteTemperature.Celsius);
            var temperatureOptimale = new Temperature(20, UniteTemperature.Celsius);
            var tempsDeCroissance = new Temps() { Valeur = 1, Unite = UniteDeTemps.Mois };

            _conditionCroissance = new ConditionCroissance()
            {
                TemperatureMinimale = temperatureMinimale,
                TemperatureOptimale = temperatureOptimale,
                TempsDeCroissance = tempsDeCroissance
            };

            return this;
        }

        public Culture Build()
        {
            return new Culture()
            {
                Id = _id,
                Nom = _name,
                ConditionGermination = _conditionGermination,
                ConditionCroissance = _conditionCroissance
            };  
        }
    }
}
