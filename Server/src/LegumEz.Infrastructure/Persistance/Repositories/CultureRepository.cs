using AutoMapper;
using LegumEz.Domain.Plantation;
using LegumEz.Domain.Plantation.Culture;
using LegumEz.Domain.Plantation.spi;
using LegumEz.Infrastructure.Persistance.Configuration;
using LegumEz.Infrastructure.Persistance.Exceptions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace LegumEz.Infrastructure.Persistance.Repositories
{
    public class CultureRepository : ICultureRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly ILogger<CultureRepository> _logger;

        public CultureRepository(ApplicationDbContext dbContext,
            IMapper mapper,
            ILogger<CultureRepository> logger)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _logger = logger;
        }

        public IEnumerable<Culture> FindAll()
        {
            _logger.LogInformation("Fetching all cultures from database.");
            
            var culturesFromDb = _dbContext.Cultures
                .AsNoTracking()
                .Select(x => x)
                .ToList();

            _logger.LogInformation("Fetched {CultureCount} cultures from database.", culturesFromDb.Count);
            
            return _mapper.Map<IEnumerable<Culture>>(culturesFromDb);
        }

        public Culture FindById(Guid id)
        {
            _logger.LogInformation("Fetching culture with Id {CultureId} from database", id);
            
            var culture = _dbContext.Cultures
                .AsNoTracking()
                .SingleOrDefault(x => x.Id == id);

            if (culture == null)
            {
                throw new EntityNotFoundException(id, typeof(DAL.Cultures.Culture),
                    $"Entity {nameof(Culture)} not found with ID {id}");
            }
            
            _logger.LogInformation("Succesfully fetched culture with Id {CultureId} from database", id);
            
            return _mapper.Map<Culture>(culture);
        }
    }
}