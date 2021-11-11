using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XBank.Domain.Core.CustomExceptions;
using XBank.Domain.Core.Entities;
using XBank.Domain.Core.Requests;
using XBank.Domain.Core.Responses;
using XBank.Domain.Shared.Handlers;
using XBank.Domain.Shared.Interfaces;
using XBank.Domain.Shared.Util;

namespace XBank.Domain.Core.Commands
{
    public class UpdateClientCommandHandler : CommandHandler<Client, UpdateClientRequest, UpdateClientResponse>
    {
        public UpdateClientCommandHandler(ICommandRepository<Client> repository) : base(repository)
        {
        }

        public override UpdateClientResponse Handle(UpdateClientRequest request)
        {
            var isClientExist = _repository.Exists(client => client.Id == request.GetId());

            if (!isClientExist)
            {
                throw new DomainException($"Customer with Id {request.GetId()} doesn't exist.", 400);
            }

            var client = _repository.Get(x => x.Id == request.GetId(), "Account");

            if (!client.IsActive && !request.GetActivate())
            {
                throw new DomainException($"You must activate the account before editing.", 400);
            }

            client.Name = request.Name;
            client.Email = request.Email;
            client.Address = request.Address;
            client.Phone = request.Phone;

            if (request.GetActivate())
            {
                client.IsActive = true;
                client.Account.IsActive = true;
            }

            _repository.Update(client);

            _repository.Save();

            return new UpdateClientResponse 
            {
                Name = client.Name,
                CPF = client.CPF,
                UpdatedAt = client.UpdatedAt,
                isActive = client.IsActive
            };
        }
    }
}
