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
    public class OpenAccountCommandHandler : CommandHandler<Client, OpenAccountRequest, Object>
    {
        public OpenAccountCommandHandler(ICommandRepository<Client> repository) : base(repository)
        {
        }

        public override object Handle(OpenAccountRequest request)
        {
            try
            {
                var client = new Client()
                {
                    Name = request.Name,
                    CPF = request.CPF,
                    Email = request.Email,
                    Address = request.Address,
                    Phone = request.Phone,
                };


                var account = new Account();
                account.ClientId = client.Id;

                client.Account = account;

                _repository.Add(client);
                _repository.Save();

                return "Criado com sucesso";
            }
            catch (Exception exc)
            {
                return "Não foi possivel criar o cliente. Erro: " + exc.Message;
            }

        }
    }
}
