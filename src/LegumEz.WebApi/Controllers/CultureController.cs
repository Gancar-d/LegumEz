using AutoMapper;
using LegumEz.Domain.Plantation;
using LegumEz.Domain.Plantation.api;
using LegumEz.WebApi.DTO;
using Microsoft.AspNetCore.Mvc;

namespace LegumEz.WebApi.Controllers
{
    [ApiController]
    [Route("api/Culture")]
    public class CultureController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IOptimizePlantation _optimizePlantation;
        private readonly IAccessCulture _accessCulture;

        public CultureController(ILogger<CultureController> logger,
            IMapper mapper,
            IOptimizePlantation optimizePlantation,
            IAccessCulture accessCulture)
        {
            _mapper = mapper;
            _optimizePlantation = optimizePlantation;
            _accessCulture = accessCulture;
        }

        [HttpGet]
        public ActionResult<IEnumerable<SimpleCultureDto>> GetCultures()
        {
            var cultures = _accessCulture.All();

            var responseData = _mapper.Map<IEnumerable<SimpleCultureDto>>(cultures);
            return Ok(responseData);
        }

        [HttpGet("{cultureId}")]
        public ActionResult<DetailedCultureDto> GetCulture(Guid cultureId)
        {
            var culture = _accessCulture.FromId(cultureId);

            var responseData = _mapper.Map<DetailedCultureDto>(culture);
            return Ok(responseData);
        }

        [HttpGet("{cultureId}/{localisation}/MoisPlantation")]
        public ActionResult<int> GetMoisPlantation(Guid cultureId, string ville)
        {
            var cultureToPlant = _accessCulture.FromId(cultureId);
            var moisOptimalPlantation = _optimizePlantation.GetMoisOptimalDePlantationByLocalisation(cultureToPlant, new Localisation(ville));
            
            return Ok((int)moisOptimalPlantation);
        }
    }
}