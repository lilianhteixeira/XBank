using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using XBank.Domain.Core.Entities;
using XBank.Domain.Infra.Contexts;
using XBank.Domain.Shared.Entities;
using XBank.Domain.Shared.Interfaces;

namespace XBank.Domain.Infra.Repositories
{
    public class CommandRepository<TEntity> : ICommandRepository<TEntity> where TEntity : Entity
    {
        private readonly XBankContext _context;

        public CommandRepository(XBankContext context)
        {
            _context = context;
        }

        public void Add(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
        }

        public TEntity GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Remove(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public TEntity Update(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            _context.SaveChanges();
        }
        //Inlcuir uma segunda expression
        public TEntity Get(Expression<Func<TEntity, bool>> predicate)
        {
            return _context.Set<TEntity>().Include(x => x.).Single(predicate);

        }
    }
}
