using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using XBank.Domain.Shared.Entities;

namespace XBank.Domain.Shared.Interfaces
{
    public interface IQueryRepository<TEntity> where TEntity : Entity
    {
        TEntity GetById(Guid id);
        IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> predicate);
        TEntity Get(Expression<Func<TEntity, bool>> predicate, string childEntity);
    }
}
