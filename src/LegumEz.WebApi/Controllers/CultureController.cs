using AutoMapper;
using LegumEz.Application.Cultures;
using Microsoft.AspNetCore.Mvc;

namespace LegumEz.WebApi.Controllers
{
    [ApiController]
    [Route("api/Culture")]
    public class CultureController : ControllerBase
    {
        private readonly ILogger<CultureController> _logger;
        private readonly ICultureService _cultureService;
        private readonly IMapper _mapper;

        public CultureController(ILogger<CultureController> logger,
            IMapper mapper,
            ICultureService cultureService)
        {
            _logger = logger;
            _mapper = mapper;
            _cultureService = cultureService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<CultureDto>> GetCultures()
        {
            var cultures = _cultureService.GetCultures();

            var responseData = _mapper.Map<IEnumerable<CultureDto>>(cultures);
            return Ok(responseData);
        }

        [HttpGet("{cultureId}")]
        public ActionResult<CultureDto> GetCulture(Guid cultureId)
        {
            var culture = _cultureService.GetCultureById(cultureId);

            var responseData = _mapper.Map<CultureDto>(culture);
            return Ok(responseData);
        }

        [HttpGet("{cultureId}/{localisation}/Periode")]
        public ActionResult<int> GetPeriodePlantation(int cultureId, string localisation)
        {
            throw new NotImplementedException();
        }
    }
}