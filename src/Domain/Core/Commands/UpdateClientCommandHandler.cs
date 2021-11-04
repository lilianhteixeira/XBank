using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XBank.Domain.Core.Entities;
using XBank.Domain.Core.Requests;
using XBank.Domain.Shared.Handlers;
using XBank.Domain.Shared.Interfaces;

namespace XBank.Domain.Core.Commands
{
    public class UpdateClientCommandHandler : CommandHandler<Client, ClientRequest, object>
    {
        public UpdateClientCommandHandler(ICommandRepository<Client> repository) : base(repository)
        {
        }

        public override object Handle(ClientRequest request)
        {
            var client = _repository.Get(x => x.CPF.Value == request.CPF);

            client.Name = request.Name;
            client.Email = request.Email;
            client.Address = request.Address;
            client.Phone = request.Phone;

            _repository.Update(client);

            _repository.Save();

            return client;
        }
    }
}
