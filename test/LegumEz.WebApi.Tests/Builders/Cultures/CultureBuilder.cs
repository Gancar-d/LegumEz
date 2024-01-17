using LegumEz.Domain.Cultures;
using LegumEz.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegumEz.WebApi.Tests.Builders.Cultures
{
    internal class CultureBuilder
    {
        private Guid _id;
        private string _name;
        private ConditionGermination _conditionGermination;
        private ConditionCroissance _conditionCroissance;

        public CultureBuilder WithRandomId()
        {
            _id = Guid.NewGuid();

            return this;
        }

        public CultureBuilder WithName(string name)
        {
            _name = name;

            return this;
        }

        public CultureBuilder WithDefaultValidConditionGermination()
        {
            var temperatureMinimale = new Temperature(10, UniteTemperature.Celsius);
            var temperatureMaximale = new Temperature(20, UniteTemperature.Celsius);
            var tempsDeLevee = new Temps(10, UniteDeTemps.Jours);

            _conditionGermination = new ConditionGermination(
                temperatureMinimale,
                temperatureMaximale,
                tempsDeLevee);

            return this;
        }
        
        public CultureBuilder WithDefaultValidConditionCroissance()
        {
            var temperatureMinimale = new Temperature(10, UniteTemperature.Celsius);
            var temperatureMaximale = new Temperature(20, UniteTemperature.Celsius);
            var tempsDeCroissance = new Temps(1, UniteDeTemps.Mois);

            _conditionCroissance = new ConditionCroissance(
                temperatureMinimale,
                temperatureMaximale,
                tempsDeCroissance);

            return this;
        }

        public Culture Build()
        {
            return new Culture(
                _id,
                _name,
                _conditionGermination,
                _conditionCroissance);
                
        }
    }
}
