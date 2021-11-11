using XBank.Domain.Shared.Entities;
using XBank.Domain.Shared.Interfaces;
using XBank.Domain.Shared.Requests;

namespace XBank.Domain.Shared.Handlers
{
    public abstract class CommandHandler<TEntity, TRequest, TResponse>
        where TRequest : Request
        where TEntity : Entity
    {
        protected readonly ICommandRepository<TEntity> _repository;

        protected CommandHandler(ICommandRepository<TEntity> repository)
        {
            _repository = repository;
        }

        public abstract TResponse Handle(TRequest request);
    }
}
