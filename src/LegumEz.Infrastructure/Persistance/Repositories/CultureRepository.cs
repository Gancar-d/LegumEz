using AutoMapper;
using LegumEz.Domain.Cultures;
using LegumEz.Infrastructure.Persistance.Configuration;
using LegumEz.Infrastructure.Persistance.DAL.Cultures;
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

        public IEnumerable<Domain.Cultures.Culture> FindAll()
        {
            var culturesFromDb = _dbContext.Cultures.Select(x => x).ToList();

            return _mapper.Map<IEnumerable<Domain.Cultures.Culture>>(culturesFromDb);
        }

        public Domain.Cultures.Culture FindById(Guid id)
        {
            var culturesFromDb = _dbContext.Cultures.Single(x => x.Id == id);

            return _mapper.Map<Domain.Cultures.Culture>(culturesFromDb);
        }
    }
}
