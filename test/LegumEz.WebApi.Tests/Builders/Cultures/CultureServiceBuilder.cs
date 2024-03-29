﻿using LegumEz.Application.Cultures;
using LegumEz.Application.Meteo;
using LegumEz.Domain.ConditionsMeteos;
using LegumEz.Domain.Cultures;
using LegumEz.Infrastructure.Persistance.Configuration;
using LegumEz.Infrastructure.Persistance.Repositories;
using LegumEz.WebApi.Tests.Builders.DbContext;
using LegumEz.WebApi.Tests.Builders.Mapper;
using Moq;

namespace LegumEz.WebApi.Tests.Builders.Cultures
{
    internal class CultureServiceBuilder
    {
        private ApplicationDbContext? _dbContext;
        private IMeteoService _meteoService = new Mock<IMeteoService>().Object;

        public CultureServiceBuilder WithInMemoryDbContext()
        {
            _dbContext = new DbContextBuilder()
                .WithUsingInMemoryDatabase()
                .Build();
            
            return this;
        }

        public CultureServiceBuilder WithPredictionMeteo()
        {
            var meteoServiceMock = new Mock<IMeteoService>();

            var predictionsMeteos = new List<ConditionMeteo>()
            {
                new ConditionMeteo(
                    new Temperature(-5, UniteTemperature.Celsius),
                    new Temperature(0, UniteTemperature.Celsius),
                    new DateTime(2024, 1, 1)),
                new ConditionMeteo(
                    new Temperature(0, UniteTemperature.Celsius), 
                    new Temperature(10, UniteTemperature.Celsius), 
                    new DateTime(2024, 2, 1)),
                new ConditionMeteo(
                    new Temperature(10, UniteTemperature.Celsius), 
                    new Temperature(20, UniteTemperature.Celsius), 
                    new DateTime(2024, 3, 1)),
                new ConditionMeteo(
                    new Temperature(20, UniteTemperature.Celsius), 
                    new Temperature(22, UniteTemperature.Celsius), 
                    new DateTime(2024, 4, 1)),
            };
            
            meteoServiceMock
                .Setup(x => x.GetPredictionsMeteoForLocalisation(It.IsAny<string>()))
                .Returns(Task.FromResult(predictionsMeteos as IEnumerable<ConditionMeteo>));

            _meteoService = meteoServiceMock.Object;

            return this;
        }

        public ICultureService Build()
        {
            if (_dbContext is null)
            {
                throw new CannotBuildException($"Cannot build {nameof(CultureService)}. Required parameter {nameof(_dbContext)} was null. Consider using {nameof(WithInMemoryDbContext)} method before building.");
            }
                
            var cultureRepository = new CultureRepository(_dbContext, MapperBuilder.Build());

            return new CultureService(cultureRepository, _meteoService);
        }
    }
}
