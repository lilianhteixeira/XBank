using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XBank.Domain.Core.Entities;
using XBank.Domain.Core.Responses;
using XBank.Domain.Shared.Handlers;
using XBank.Domain.Shared.Interfaces;
using XBank.Domain.Shared.Requests;

namespace XBank.Domain.Core.Queries
{
    public class GetClientHandler : QueryHandler<Client, GetByIdRequest, GetClientResponse>
    {
        public GetClientHandler(IQueryRepository<Client> repository) : base(repository)
        {
        }

        public override GetClientResponse Handle(GetByIdRequest request)
        {
            var client = _repository
                .GetById(request.GetId());

            var response = new GetClientResponse(client);

            return response;
        }
    }
}
