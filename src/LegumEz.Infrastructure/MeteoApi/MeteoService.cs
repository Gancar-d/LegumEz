using AutoMapper;
using Azure.Identity;
using LegumEz.Application.Meteo;
using LegumEz.Domain.PredictionsMeteos;
using LegumEz.Infrastructure.Options;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace LegumEz.Infrastructure.MeteoApi;

public class MeteoService : IMeteoService
{
    private readonly string _apiKey;
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly IMapper _mapper;
    private readonly ILogger<MeteoService> _logger;
    
    public MeteoService(IHttpClientFactory httpClientFactory,
        IOptions<MeteoApiKey> meteoApiKeyOption,
        IMapper mapper,
        ILogger<MeteoService> logger)
    {
        _httpClientFactory = httpClientFactory;
        _apiKey = meteoApiKeyOption.Value.Key;
        _mapper = mapper;
        _logger = logger;
    }
    
    public async Task<IEnumerable<PredictionMeteo>> GetPredictionsMeteoForLocalisation(string localisation)
    {
        var currentDate = DateTime.Now.ToString("yyyy-MM-dd");
        var endDate = DateTime.Now.AddMonths(3).ToString("yyyy-MM-dd");
        
        _logger.LogInformation("Getting predictions meteo de {Localisation} a partir de {StartDate} jusqu'a {EndDate}", 
            localisation, currentDate, endDate);
        
        var predictionMeteos = await GetPredictionsMeteoByDateAndLocalisation(localisation, currentDate, endDate);

        _logger.LogInformation("Got predictions meteo de {Localisation} a partir de {StartDate} jusqu'a {EndDate}",
            localisation, currentDate, endDate);
        
        return predictionMeteos;
    }

    private async Task<IEnumerable<PredictionMeteo>> GetPredictionsMeteoByDateAndLocalisation(string localisation, string startDate, string endDate)
    {
        var httpclient = _httpClientFactory.CreateClient("MeteoApi");
        
        var response = await httpclient
            .GetAsync($"/timeline/{localisation}/{startDate}/{endDate}?unitGroup=metric&key={_apiKey}&contentType=json");
        response.EnsureSuccessStatusCode();
        
        var stream = await response.Content.ReadAsStringAsync();        
        var forecast = JsonConvert.DeserializeObject<MeteoForecast>(stream);
        
        var predictionMeteos = _mapper.Map<IEnumerable<PredictionMeteo>>(forecast.Days);
        
        return predictionMeteos;
    }
}