using AutoMapper;
using LegumEz.Application.Meteo;
using LegumEz.Domain.PredictionsMeteos;
using LegumEz.Infrastructure.Options;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace LegumEz.Infrastructure.MeteoApi;

public class MeteoService : IMeteoService
{
    private readonly string _apiKey;
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly IMapper _mapper;
    
    public MeteoService(IHttpClientFactory httpClientFactory,
        IOptions<MeteoApiKey> meteoApiKeyOption,
        IMapper mapper)
    {
        _httpClientFactory = httpClientFactory;
        _apiKey = meteoApiKeyOption.Value.Key;
        _mapper = mapper;
    }
    
    public async Task<IEnumerable<PredictionMeteo>> GetPredictionsMeteoForLocalisation(string localisation)
    {
        var httpclient = _httpClientFactory.CreateClient("MeteoApi");

        var currentDate = DateTime.Now.ToString("yyyy-MM-dd");
        var endDate = DateTime.Now.AddMonths(3).ToString("yyyy-MM-dd");
        
        var response = await httpclient
            .GetAsync(
                $"timeline/{localisation}/{currentDate}/{endDate}?unitGroup=metric&key={_apiKey}&contentType=json");

        response.EnsureSuccessStatusCode();
        var stream = await response.Content.ReadAsStringAsync();

        var forecast = JsonConvert.DeserializeObject<MeteoForecast>(stream);
        
        var predictionMeteos = _mapper.Map<IEnumerable<PredictionMeteo>>(forecast.Days);
        return predictionMeteos;
    }
}