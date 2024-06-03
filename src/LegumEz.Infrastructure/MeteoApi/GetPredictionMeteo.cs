using AutoMapper;
using LegumEz.Application.Meteo;
using LegumEz.Domain.Meteo;
using LegumEz.Infrastructure.Options;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace LegumEz.Infrastructure.MeteoApi;

public class GetPredictionMeteo : Domain.Meteo.spi.GetPredictionMeteo
{
    private readonly string _apiKey;
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly IMapper _mapper;
    private readonly ILogger<GetPredictionMeteo> _logger;
    
    public GetPredictionMeteo(IHttpClientFactory httpClientFactory,
        IOptions<MeteoApiKey> meteoApiKeyOption,
        IMapper mapper,
        ILogger<GetPredictionMeteo> logger)
    {
        _httpClientFactory = httpClientFactory;
        _apiKey = meteoApiKeyOption.Value.Key;
        _mapper = mapper;
        _logger = logger;
    }
    
    public IEnumerable<PredictionMeteo> ForLocalisation(Localisation localisation)
    {
        var currentDate = DateTime.Now.ToString("yyyy-MM-dd");
        var endDate = DateTime.Now.AddMonths(3).ToString("yyyy-MM-dd");
        
        _logger.LogInformation("Getting predictions meteo de {Localisation} a partir de {StartDate} jusqu'a {EndDate}", 
            localisation, currentDate, endDate);
        
        var predictionMeteos = GetPredictionsMeteoByDateAndLocalisation(localisation, currentDate, endDate);

        _logger.LogInformation("Got predictions meteo de {Localisation} a partir de {StartDate} jusqu'a {EndDate}",
            localisation, currentDate, endDate);
        
        return predictionMeteos;
    }

    private IEnumerable<PredictionMeteo> GetPredictionsMeteoByDateAndLocalisation(Localisation localisation, string startDate, string endDate)
    {
        var httpclient = _httpClientFactory.CreateClient("MeteoApi");
        
        var response = httpclient
            .GetAsync($"/timeline/{localisation.Ville}/{startDate}/{endDate}?unitGroup=metric&key={_apiKey}&contentType=json")
            .Result;
        response.EnsureSuccessStatusCode();
        
        var stream = response.Content.ReadAsStringAsync().Result;        
        var forecast = JsonConvert.DeserializeObject<MeteoForecast>(stream);
        
        var predictionMeteos = _mapper.Map<IEnumerable<PredictionMeteo>>(forecast.Days);
        
        return predictionMeteos;
    }
}