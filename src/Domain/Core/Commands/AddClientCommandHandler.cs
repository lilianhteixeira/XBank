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
    public class AddClientCommandHandler : CommandHandler<Client, AddClientRequest, Object>
    {
        public AddClientCommandHandler(ICommandRepository<Client> repository) : base(repository)
        {
        }

        public override object Handle(AddClientRequest request)
        {
            //try
            //{
            //    var client = new Client() 
            //    { 
            //        Name = request.Name,
            //        CPF = request.CPF,
            //        Email = request.Email,
            //        Address = request.Address,
            //        Phone = request.Phone
            //    };

            //    _repository.Add(client);
            //    _repository.Save();

            //    return "Criado com sucesso";
            //}
            //catch (Exception exc)
            //{
            //    return "Não foi possivel criar o cliente. Erro: " + exc.Message;
            //}

            var account = new Account();

            var client = new Client()
            {
                Name = request.Name,
                CPF = request.CPF,
                Email = request.Email,
                Address = request.Address,
                Phone = request.Phone,
                AccountId = account.Id
            };
            account.Client = client;

            _repository.Add(client);
            _repository.Save();

            return null;
        }
    }
}
