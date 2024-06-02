using LegumEz.Domain.Cultures;
using LegumEz.Domain.SharedKernel;

namespace LegumEz.Domain.Tests.Cultures
{
    public class CultureShould
    {
        [Fact]
        public void SetName_WhenCreated()
        {
            var tempsDeCroissance = new Temps(1, UniteDeTemps.Jours);
            var tempsDeLevee = new Temps(1, UniteDeTemps.Jours);

            var conditionDeCroissance = new ConditionCroissance(new Temperature(0, UniteTemperature.Celsius), new Temperature(1, UniteTemperature.Celsius), tempsDeCroissance);
            var conditionGermination = new ConditionGermination(new Temperature(0, UniteTemperature.Celsius), new Temperature(1, UniteTemperature.Celsius), tempsDeLevee);

            var legume = new Culture(Guid.NewGuid(), "name", conditionGermination, conditionDeCroissance);

            Assert.Equal("name", legume.Nom);
        }

        [Fact]
        public void SetConditionGermination_WhenCreated()
        {
            var tempsDeCroissance = new Temps(1, UniteDeTemps.Jours);
            var tempsDeLevee = new Temps(1, UniteDeTemps.Jours);

            var conditionDeCroissance = new ConditionCroissance(new Temperature(0, UniteTemperature.Celsius), new Temperature(1, UniteTemperature.Celsius), tempsDeCroissance);
            var conditionGermination = new ConditionGermination(new Temperature(0, UniteTemperature.Celsius), new Temperature(1, UniteTemperature.Celsius), tempsDeLevee);

            var legume = new Culture(Guid.NewGuid(), "name", conditionGermination, conditionDeCroissance);

            Assert.Equal(conditionGermination, legume.ConditionGermination);
        }

        [Fact]
        public void SetConditionDeCroissance_WhenCreated()
        {
            var tempsDeCroissance = new Temps(1, UniteDeTemps.Jours);
            var tempsDeLevee = new Temps(1, UniteDeTemps.Jours);

            var conditionDeCroissance = new ConditionCroissance(new Temperature(0, UniteTemperature.Celsius), new Temperature(1, UniteTemperature.Celsius), tempsDeCroissance);
            var conditionGermination = new ConditionGermination(new Temperature(0, UniteTemperature.Celsius), new Temperature(1, UniteTemperature.Celsius), tempsDeLevee);

            var legume = new Culture(Guid.NewGuid(), "name", conditionGermination, conditionDeCroissance);

            Assert.Equal(conditionDeCroissance, legume.ConditionCroissance);
        }

        [Fact]
        public void ThrowException_IfCreatedWithEmptyStringForName()
        {
            var tempsDeCroissance = new Temps(1, UniteDeTemps.Jours);
            var tempsDeLevee = new Temps(1, UniteDeTemps.Jours);

            var conditionDeCroissance = new ConditionCroissance(new Temperature(0, UniteTemperature.Celsius), new Temperature(1, UniteTemperature.Celsius), tempsDeCroissance);
            var conditionGermination = new ConditionGermination(new Temperature(0, UniteTemperature.Celsius), new Temperature(1, UniteTemperature.Celsius), tempsDeCroissance);

            Assert.Throws<ArgumentException>(() => new Culture(Guid.NewGuid(), "", conditionGermination, conditionDeCroissance));
        }

        [Fact]
        public void ThrowException_IfConditionGerminationIsNull()
        {
            var tempsDeCroissance = new Temps(1, UniteDeTemps.Jours);
            var conditionDeCroissance = new ConditionCroissance(new Temperature(0, UniteTemperature.Celsius), new Temperature(1, UniteTemperature.Celsius), tempsDeCroissance);

            Assert.Throws<ArgumentNullException>(() => new Culture(Guid.NewGuid(), "name", null, conditionDeCroissance));
        }

        [Fact]
        public void ThrowException_IfConditionDeCroissanceIsNull()
        {
            var tempsDeLevee = new Temps(1, UniteDeTemps.Jours);
            var conditionGermination = new ConditionGermination(new Temperature(0, UniteTemperature.Celsius), new Temperature(1, UniteTemperature.Celsius), tempsDeLevee);

            Assert.Throws<ArgumentNullException>(() => new Culture(Guid.NewGuid(), "name", conditionGermination, null));
        }
    }
}