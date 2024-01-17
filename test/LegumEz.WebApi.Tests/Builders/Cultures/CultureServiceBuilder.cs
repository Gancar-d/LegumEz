using LegumEz.Application.Cultures;
using LegumEz.Domain.Cultures;
using LegumEz.Domain.Entity;
using Moq;

namespace LegumEz.WebApi.Tests.Builders.Cultures
{
    internal class CultureServiceBuilder
    {
        private Mock<ICultureRepository> _cultureRepositoryMock;

        public CultureServiceBuilder()
        {
            _cultureRepositoryMock = new Mock<ICultureRepository>();
        }

        public CultureServiceBuilder WithAllCultures()
        {
            var allCultures = new List<Culture>
            {
                new CultureBuilder()
                .WithRandomId()
                .WithName("Tomate")
                .WithDefaultValidConditionGermination()
                .WithDefaultValidConditionCroissance()
                .Build(),
                new CultureBuilder()
                .WithRandomId()
                .WithName("Carotte")
                .WithDefaultValidConditionGermination()
                .WithDefaultValidConditionCroissance()
                .Build(),
                new CultureBuilder()
                .WithRandomId()
                .WithName("Salade")
                .WithDefaultValidConditionGermination()
                .WithDefaultValidConditionCroissance()
                .Build(),
            };

            _cultureRepositoryMock
                .Setup(x => x.FindAll())
                .Returns(allCultures);

            return this;
        }

        public ICultureService Build()
        {
            return new CultureService(_cultureRepositoryMock.Object);
        }
    }
}
