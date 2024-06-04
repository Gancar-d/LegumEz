using AutoMapper;
using LegumEz.Domain.Plantation;
using LegumEz.Domain.Plantation.api;
using LegumEz.Domain.Plantation.api.dto;
using Microsoft.AspNetCore.Mvc;

namespace LegumEz.WebApi.Controllers
{
    [ApiController]
    [Route("api/Culture")]
    public class CultureController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly Plantation _plantation;

        public CultureController(ILogger<CultureController> logger,
            IMapper mapper,
            Plantation plantation)
        {
            _mapper = mapper;
            _plantation = plantation;
        }

        [HttpGet]
        public ActionResult<IEnumerable<SimpleCultureDto>> GetCultures()
        {
            var cultures = _plantation.GetAllCultures();

            var responseData = _mapper.Map<IEnumerable<SimpleCultureDto>>(cultures);
            return Ok(responseData);
        }

        [HttpGet("{cultureId}")]
        public ActionResult<DetailedCultureDto> GetCulture(Guid cultureId)
        {
            var culture = _plantation.GetCultureFromId(cultureId);

            var responseData = _mapper.Map<DetailedCultureDto>(culture);
            return Ok(responseData);
        }

        [HttpGet("{cultureId}/{localisation}/MoisPlantation")]
        public ActionResult<int> GetMoisPlantation(Guid cultureId, string ville)
        {
            var meilleurMoisDePlantation = _plantation.GetMoisOptimalDePlantationByLocalisation(cultureId, new Localisation(ville));
            
            return Ok((int)meilleurMoisDePlantation);
        }
    }
}