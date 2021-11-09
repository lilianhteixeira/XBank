using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XBank.Domain.Core.Entities;
using XBank.Domain.Core.Requests;
using XBank.Domain.Shared.Handlers;
using XBank.Domain.Shared.Interfaces;

namespace XBank.Domain.Core.Queries
{
    public class GetAccountMovementsHandler : QueryHandler<Account, GetAccountMovementsRequest, IEnumerable<Movement>>
    {
        public GetAccountMovementsHandler(IQueryRepository<Account> repository) : base(repository)
        {
        }

        public override IEnumerable<Movement> Handle(GetAccountMovementsRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
