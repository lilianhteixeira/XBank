using System.Collections.Generic;
using XBank.Domain.Core.Entities;
using XBank.Domain.Core.Requests;
using XBank.Domain.Shared.Handlers;
using XBank.Domain.Shared.Interfaces;
using XBank.Domain.Shared.Util;

namespace XBank.Domain.Core.Queries
{
    public class GetAllClientQueryHandler : QueryHandler<Client, GetAllClientRequest, IEnumerable<Client>>
    {
        public GetAllClientQueryHandler(IQueryRepository<Client> repository) : base (repository)
        {

        }

        public override IEnumerable<Client> Handle(GetAllClientRequest request)
        {
            var predicate = PredicateBuilder.New<Client>();

            if (request.Active != null) predicate = predicate.And(x => x.IsActive == request.Active);

            if (request.Name != null) predicate = predicate.And(x => x.Name == request.Name);

            return base._repository.Get(predicate);
        }
    }
}
