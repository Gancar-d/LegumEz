using AutoMapper;
using LegumEz.Domain.Plantation;
using LegumEz.Domain.Plantation.spi;
using LegumEz.Infrastructure.Persistance.Configuration;
using LegumEz.Infrastructure.Persistance.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace LegumEz.Infrastructure.Persistance.Repositories
{
    public class CultureRepository : ICultureRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public CultureRepository(ApplicationDbContext dbContext,
            IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public IEnumerable<Culture> FindAll()
        {
            var culturesFromDb = _dbContext.Cultures
                .AsNoTracking()
                .Select(x => x)
                .ToList();

            return _mapper.Map<IEnumerable<Culture>>(culturesFromDb);
        }

        public Culture FindById(Guid id)
        {
            var culture = _dbContext.Cultures
                .AsNoTracking()
                .SingleOrDefault(x => x.Id == id);

            if (culture == null)
            {
                throw new EntityNotFoundException(id, typeof(DAL.Cultures.Culture),
                    $"Entity {nameof(Culture)} not found with ID {id}");
            }
            
            return _mapper.Map<Culture>(culture);
        }
    }
}