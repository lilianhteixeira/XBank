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
    public class RemoveAccountCommandHandler : CommandHandler<Client, RemoveAccountRequest, Object>
    {
        public RemoveAccountCommandHandler(ICommandRepository<Client> repository) : base(repository)
        {
        }

        public override object Handle(RemoveAccountRequest request)
        {
            var client = _repository.Get(x => x.CPF == request.CPF);
            client.IsActive = false;
            _repository.Save();
            return client;
        }
    }
}