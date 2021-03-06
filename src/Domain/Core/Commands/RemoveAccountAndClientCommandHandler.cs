using XBank.Domain.Core.CustomExceptions;
using XBank.Domain.Core.Entities;
using XBank.Domain.Shared.Handlers;
using XBank.Domain.Shared.Interfaces;
using XBank.Domain.Shared.Requests;

namespace XBank.Domain.Core.Commands
{
    public class RemoveAccountAndClientCommandHandler : CommandHandler<Client, GetByIdRequest, object>
    {
        public RemoveAccountAndClientCommandHandler(ICommandRepository<Client> repository) : base(repository)
        {
        }

        public override object Handle(GetByIdRequest request)
        {

            var isClientExist = _repository.Exists(client => client.Id == request.GetId());

            if (!isClientExist)
            {
                throw new DomainException($"Customer with Id {request.GetId()} doesn't exist.", 400);
            }

            var client = _repository.Get(x => x.Id == request.GetId(), "Account");

            if (client.Account.Balance > 0)
            {
                throw new DomainException($"Customer with Id {request.GetId()} have funds. Pleaser withdraw all funds.", 400);
            }

            client.IsActive = false;
            client.Account.IsActive = false;
            _repository.Save();
            
            return null;
        }
    }
}