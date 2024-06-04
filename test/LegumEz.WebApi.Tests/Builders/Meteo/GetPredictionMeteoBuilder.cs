using LegumEz.Domain.Meteo;
using LegumEz.Domain.SharedKernel;
using LegumEz.Infrastructure.MeteoApi;
using Moq;
using GetPredictionMeteo = LegumEz.Domain.Meteo.spi.GetPredictionMeteo;

namespace LegumEz.WebApi.Tests.Builders.Meteo;

public class GetPredictionMeteoBuilder
{
    private GetPredictionMeteo _getPredictionMeteo = new Mock<GetPredictionMeteo>().Object;

    public GetPredictionMeteoBuilder WithPredictionsMeteo()
    {
        var meteoServiceMock = new Mock<GetPredictionMeteo>();

        var predictionsMeteos = new List<PredictionMeteo>()
        {
            new PredictionMeteo(
                new Temperature(-5, UniteTemperature.Celsius),
                new Temperature(0, UniteTemperature.Celsius),
                new DateTime(2024, 1, 1)),
            new PredictionMeteo(
                new Temperature(0, UniteTemperature.Celsius), 
                new Temperature(10, UniteTemperature.Celsius), 
                new DateTime(2024, 2, 1)),
            new PredictionMeteo(
                new Temperature(10, UniteTemperature.Celsius), 
                new Temperature(20, UniteTemperature.Celsius), 
                new DateTime(2024, 3, 1)),
            new PredictionMeteo(
                new Temperature(20, UniteTemperature.Celsius), 
                new Temperature(22, UniteTemperature.Celsius), 
                new DateTime(2024, 4, 1)),
        };
            
        meteoServiceMock
            .Setup(x => x.ForLocalisation(It.IsAny<Localisation>()))
            .Returns(predictionsMeteos as IEnumerable<PredictionMeteo>);

        _getPredictionMeteo = meteoServiceMock.Object;

        return this;
    }
    
    public GetPredictionMeteo Build()
    {
        return _getPredictionMeteo;
    }
}