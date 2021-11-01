using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public IEnumerable<TEntity> Get()
        {
            throw new NotImplementedException();
        }

        public TEntity GetById(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
