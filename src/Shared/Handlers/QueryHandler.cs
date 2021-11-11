using XBank.Domain.Shared.Entities;
using XBank.Domain.Shared.Interfaces;
using XBank.Domain.Shared.Requests;

namespace XBank.Domain.Shared.Handlers
{
    public abstract class QueryHandler<TEntity, TRequest, TResponse>
        where TEntity : Entity
        where TRequest : Request
    {
        protected readonly IQueryRepository<TEntity> _repository;

        public QueryHandler(IQueryRepository<TEntity> repository)
        {
            _repository = repository;
        }

        public abstract TResponse Handle(TRequest request);
    }
}