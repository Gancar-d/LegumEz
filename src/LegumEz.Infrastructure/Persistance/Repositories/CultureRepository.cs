using AutoMapper;
using LegumEz.Domain.Cultures;
using LegumEz.Infrastructure.Persistance.Configuration;
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
            var culturesFromDb = _dbContext.Cultures
                .AsNoTracking()
                .Single(x => x.Id == id);

            return _mapper.Map<Culture>(culturesFromDb);
        }
    }
}