using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using XBank.Domain.Infra.Contexts;
using XBank.Domain.Shared.Entities;
using XBank.Domain.Shared.Interfaces;

namespace XBank.Domain.Infra.Repositories
{
    public class QueryRepository<TEntity> : IQueryRepository<TEntity> where TEntity : Entity
    {
        private readonly XBankContext _context;

        public QueryRepository(XBankContext context)
        {
            _context = context;
        }

        public IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> predicate = null)
        {
            return predicate == null
                ? _context.Set<TEntity>().AsNoTracking().ToList()
                : _context.Set<TEntity>().AsNoTracking().Where(predicate);
        }

        public TEntity GetById(Guid id)
        {
            return _context.Set<TEntity>().AsNoTracking().Single(x => x.Id == id);
        }

        public TEntity Get(Expression<Func<TEntity, bool>> predicate, string childEntity = null)
        {
            if (childEntity != null)
            {
                return _context.Set<TEntity>()
                    .AsNoTracking()
                    .Include(childEntity)
                    .Single(predicate);
            }

            return _context.Set<TEntity>()
                .AsNoTracking()
                .Single(predicate);

        }
    }
}
