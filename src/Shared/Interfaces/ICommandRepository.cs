using System;
using System.Linq.Expressions;
using XBank.Domain.Shared.Entities;

namespace XBank.Domain.Shared.Interfaces
{
    public interface ICommandRepository<TEntity> where TEntity : Entity
    {
        void Add(TEntity entity);

        TEntity Update(TEntity entity);

        void Remove(TEntity entity);

        TEntity GetById(Guid id);

       TEntity Get(
           Expression<Func<TEntity, bool>> predicate,
           string childEntity = null);

        bool Exists(Expression<Func<TEntity, bool>> predicate);


        void Save();
    }
}
