using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;
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

        public TEntity Get(Expression<Func<TEntity, bool>> predicate, string childEntity = null)
        {
            if (childEntity != null)
            {
                return _context.Set<TEntity>().Include(childEntity).SingleOrDefault(predicate);
            }

            return _context.Set<TEntity>().SingleOrDefault(predicate);

        }

        public bool Exists(Expression<Func<TEntity, bool>> predicate)
        {
            return _context.Set<TEntity>().Any(predicate);
        }

        public TEntity GetById(Guid id)
        {
            return Get(x => x.Id == id);
        }

        public void Remove(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
        }

        public TEntity Update(TEntity entity)
        {
            entity.UpdatedAt = DateTime.Now;
            _context.Set<TEntity>().Update(entity);

            return entity;
        }


        public void Save()
        {
            _context.SaveChanges();
        }

    }
}
