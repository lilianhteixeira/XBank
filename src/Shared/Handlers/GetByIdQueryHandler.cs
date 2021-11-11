using XBank.Domain.Shared.Entities;
using XBank.Domain.Shared.Interfaces;
using XBank.Domain.Shared.Requests;

namespace XBank.Domain.Shared.Handlers
{
    public class GetByIdQueryHandler<TEntity> : QueryHandler<TEntity, GetByIdRequest, TEntity> where TEntity : Entity
    {
        public GetByIdQueryHandler(IQueryRepository<TEntity> repository) : base(repository)
        {

        }

        public override TEntity Handle(GetByIdRequest request)
        {
                return _repository.GetById(request.GetId());
        }
    }
}
