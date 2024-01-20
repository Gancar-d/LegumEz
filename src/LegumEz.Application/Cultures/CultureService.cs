using LegumEz.Domain.Cultures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegumEz.Application.Cultures
{
    public class CultureService : ICultureService
    {
        private readonly ICultureRepository _cultureRepository;

        public CultureService(ICultureRepository cultureRepository)
        {
            _cultureRepository = cultureRepository;
        }

        public IEnumerable<Culture> GetCultures()
        {
            return _cultureRepository.FindAll();
        }

        public Culture GetCultureById(Guid cultureId)
        {
            return _cultureRepository.FindById(cultureId);
        }
    }
}
