using System.Collections.Generic;
using System.Linq;
using XBank.Domain.Core.Entities;
using XBank.Domain.Core.Responses;
using XBank.Domain.Shared.Handlers;
using XBank.Domain.Shared.Interfaces;
using XBank.Domain.Shared.Requests;

namespace XBank.Domain.Core.Queries
{
    public class GetAccountMovementsHandler : QueryHandler<Movement, GetByIdRequest, IEnumerable<GetAccountMovementsResponse>>
    {
        public GetAccountMovementsHandler(IQueryRepository<Movement> repository) : base(repository)
        {
        }

        public override IEnumerable<GetAccountMovementsResponse> Handle(GetByIdRequest request)
        {
            var result = _repository
                .Get(movement => movement.AccountId == request.GetId());

            return result.Select(movement => new GetAccountMovementsResponse(movement));
        }
    }
}
