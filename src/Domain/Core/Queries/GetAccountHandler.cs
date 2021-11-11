using System;
using XBank.Domain.Core.Entities;
using XBank.Domain.Core.Responses;
using XBank.Domain.Shared.Handlers;
using XBank.Domain.Shared.Interfaces;
using XBank.Domain.Shared.Requests;

namespace XBank.Domain.Core.Queries
{
    public class GetAccountHandler : QueryHandler<Account, GetByIdRequest, Object>
    {
        public GetAccountHandler(IQueryRepository<Account> repository) : base(repository)
        {
        }

        public override object Handle(GetByIdRequest request)
        {
            var result = _repository
                .Get(account => account.Id == request.GetId(), "Client");

            var response = new GetAccountResponse(result);

            return response;
        }
    }
}
