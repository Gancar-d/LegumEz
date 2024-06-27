using System.Dynamic;
using FluentAssertions;
using FluentAssertions.Execution;
using LegumEz.Domain.Meteo;
using LegumEz.Domain.Meteo.api;
using LegumEz.Domain.Meteo.spi;
using LegumEz.Domain.SharedKernel;
using LegumEz.WebApi.Controllers;
using LegumEz.WebApi.DTO;
using LegumEz.WebApi.Tests.ActionResultHelpers;
using LegumEz.WebApi.Tests.Builders.Mapper;
using LegumEz.WebApi.Tests.Builders.Meteo;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace LegumEz.WebApi.Tests.Meteo;

public class MeteoControllerShould
{
    [Fact]
    public void ReturnWeatherData_given_valid_city_name_and_valid_date_range()
    {
        //Arrange
        var cityName = "Montpellier";
        var startDate = new DateTime(2024, 06, 24);
        var endDate = new DateTime(2024, 06, 30);
        var expectedLocalisation = new Localisation(cityName);

        var getPredictionMeteo = new GetPredictionMeteoBuilder()
            .WithPredictionsMeteoInRange(startDate, endDate)
            .Build();
        var meteoForecaster = new MeteoForecaster(getPredictionMeteo);
        var meteoController = new MeteoController(meteoForecaster, MapperBuilder.Build());

        var mockedForecast = getPredictionMeteo.FromDateRange(expectedLocalisation, startDate, endDate).ToList();
        
        var expectedForecast = mockedForecast.Select(x => new PredictionMeteoDto(
            new TemperatureDto() { Valeur = x.TemperatureMinimale.Valeur, Unite = x.TemperatureMinimale.Unite },
            new TemperatureDto() { Valeur = x.TemperatureMaximale.Valeur, Unite = x.TemperatureMaximale.Unite },
            new TemperatureDto() { Valeur = x.TemperatureMoyenne.Valeur, Unite = x.TemperatureMoyenne.Unite },
            x.Jour
        ));

        //Act
        var forecast = meteoController.GetFromDateRange(cityName, startDate, endDate);

        //Assert
        CheckThatForecastIsExpectedOne(forecast, expectedForecast);
    }

    private static void CheckThatForecastIsExpectedOne(ActionResult<IEnumerable<PredictionMeteoDto>> forecast, IEnumerable<PredictionMeteoDto> expectedForecast)
    {
        var okResult = forecast.Result as OkObjectResult;

        using (new AssertionScope())
        {
            okResult?.CheckIsOk200();

            okResult?.Value.Should().NotBeNull();
            okResult?.Value.Should().BeEquivalentTo(expectedForecast);
        }
    }
}