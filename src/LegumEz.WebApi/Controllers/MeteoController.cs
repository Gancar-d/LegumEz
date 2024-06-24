using AutoMapper;
using LegumEz.Domain.Meteo;
using LegumEz.Domain.Meteo.api;
using LegumEz.WebApi.DTO;
using Microsoft.AspNetCore.Mvc;

namespace LegumEz.WebApi.Controllers
{
    [ApiController]
    [Route("api/Meteo")]
    public class MeteoController : ControllerBase
    {
        private readonly IMeteoForecast _meteoForecast;
        private readonly IMapper _mapper;
        
        public MeteoController(IMeteoForecast meteoForecast,
            IMapper mapper)
        {
            _meteoForecast = meteoForecast;
            _mapper = mapper;
        }

        [HttpGet("{city}")]
        public ActionResult<IEnumerable<PredictionMeteoDto>> GetFromDateRange(string city, DateTime startDate, DateTime endDate)
        {
            var predictionMeteos = _meteoForecast.FromDateRange(new Localisation(city), startDate, endDate);
            
            var responseData = _mapper.Map<IEnumerable<PredictionMeteoDto>>(predictionMeteos);
            return Ok(responseData);
        }
    }
}