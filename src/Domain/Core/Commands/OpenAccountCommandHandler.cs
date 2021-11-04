using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XBank.Domain.Core.Entities;
using XBank.Domain.Core.Requests;
using XBank.Domain.Core.Responses;
using XBank.Domain.Shared.Handlers;
using XBank.Domain.Shared.Interfaces;
using XBank.Domain.Shared.ValueObjects;

namespace XBank.Domain.Core.Commands
{
    public class OpenAccountCommandHandler : CommandHandler<Client, ClientRequest, OpenAccountResponse>
    {
        public OpenAccountCommandHandler(ICommandRepository<Client> repository) : base(repository)
        {
        }

        public override OpenAccountResponse Handle(ClientRequest request)
        {
            // todo ajustar expressão que está dando erro
            var isClientExist = _repository.Get(client => client.CPF.Value == request.CPF);

            if (isClientExist != null)
            {
                throw new InvalidOperationException($"Cliente com o CPF {request.CPF} já cadastrado. Por favor utilizar a rota de atualização");
            }

            var client = new Client()
            {
                Name = request.Name,
                CPF = new CPF(request.CPF),
                Email = request.Email,
                Address = request.Address,
                Phone = request.Phone,
            };


            var account = new Account();
            // account.ClientId = client.Id;

            client.Account = account;

            _repository.Add(client);
            _repository.Save();

            var response = new OpenAccountResponse {
                AccountId = account.Id,
                CPF = client.CPF,
                CreatedAt = account.CreatedAt
            };

            return response;
        }
    }
}
