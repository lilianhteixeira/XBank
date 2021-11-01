using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XBank.Domain.Shared.Entities;

namespace XBank.Domain.Shared.Interfaces
{
    public interface IQueryRepository<TEntity> where TEntity : Entity
    {
        TEntity GetById(Guid id);
        IEnumerable<TEntity> Get();
    }
}
