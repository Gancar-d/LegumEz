using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegumEz.Domain.Repository
{
    public interface IRepository<TEntity>
        where TEntity: class
    {
        TEntity FindById(Guid id);
        IEnumerable<TEntity> FindAll();
    }
}
