using LegumEz.Domain.Meteo;
using LegumEz.Domain.SharedKernel;
using LegumEz.Infrastructure.MeteoApi;
using Moq;
using GetPredictionMeteo = LegumEz.Domain.Meteo.spi.GetPredictionMeteo;

namespace LegumEz.WebApi.Tests.Builders.Meteo;

public class GetPredictionMeteoBuilder
{
    private Mock<GetPredictionMeteo> _getPredictionMeteo = new Mock<GetPredictionMeteo>();

    public GetPredictionMeteoBuilder WithPredictionsMeteoForLocalisation()
    {
        var predictionsMeteos = new List<PredictionMeteo>()
        {
            new PredictionMeteo(
                new Temperature(-5, UniteTemperature.Celsius),
                new Temperature(0, UniteTemperature.Celsius),
                new Temperature(-2.5, UniteTemperature.Celsius),
                new DateTime(2024, 1, 1)),
            new PredictionMeteo(
                new Temperature(0, UniteTemperature.Celsius), 
                new Temperature(10, UniteTemperature.Celsius),
                new Temperature(5, UniteTemperature.Celsius),
                new DateTime(2024, 2, 1)),
            new PredictionMeteo(
                new Temperature(10, UniteTemperature.Celsius), 
                new Temperature(20, UniteTemperature.Celsius), 
                new Temperature(15, UniteTemperature.Celsius),
                new DateTime(2024, 3, 1)),
            new PredictionMeteo(
                new Temperature(20, UniteTemperature.Celsius), 
                new Temperature(22, UniteTemperature.Celsius), 
                new Temperature(21, UniteTemperature.Celsius),
                new DateTime(2024, 4, 1)),
        };
            
        _getPredictionMeteo
            .Setup(x => x.ForLocalisation(It.IsAny<Localisation>()))
            .Returns(predictionsMeteos as IEnumerable<PredictionMeteo>);

        return this;
    }

    public GetPredictionMeteoBuilder WithPredictionsMeteoInRange(DateTime startDate, DateTime endDate)
    {
        if (startDate > endDate)
        {
            throw new ArgumentException("The start date cannot be greater than the end date.");
        }
        
        var meteoServiceMock = new Mock<GetPredictionMeteo>();
        var predictionsMeteos = new List<PredictionMeteo>();
        var random = new Random();

        while (startDate <= endDate)
        {
            var temperatureMin = random.Next(-10, 5);
            var temperatureMax = random.Next(temperatureMin, 21);
            var temperatureMoyenne = random.Next(temperatureMin, temperatureMax);
            
            var predictionMeteo = new PredictionMeteo(
                new Temperature(temperatureMin, UniteTemperature.Celsius),
                new Temperature(temperatureMax, UniteTemperature.Celsius),
                new Temperature(temperatureMoyenne, UniteTemperature.Celsius),
                startDate);
            
            predictionsMeteos.Add(predictionMeteo);
            startDate = startDate.AddDays(1);
        }
        
        _getPredictionMeteo
            .Setup(x => x.FromDateRange(It.IsAny<Localisation>(), startDate, endDate))
            .Returns(predictionsMeteos as IEnumerable<PredictionMeteo>);

        return this;
    }
    
    public GetPredictionMeteo Build()
    {
        return _getPredictionMeteo.Object;
    }
}