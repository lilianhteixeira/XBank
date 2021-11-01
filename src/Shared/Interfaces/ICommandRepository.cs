using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XBank.Domain.Shared.Entities;

namespace XBank.Domain.Shared.Interfaces
{
    public interface ICommandRepository<TEntity> where TEntity : Entity
    {
        void Add(TEntity entity);

        TEntity Update(TEntity entity);

        void Remove(TEntity entity);

        TEntity GetById(Guid id);

        void Save();
    }
}
