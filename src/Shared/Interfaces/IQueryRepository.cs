using System;
using System.Collections.Generic;
using System.Linq.Expressions;
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
