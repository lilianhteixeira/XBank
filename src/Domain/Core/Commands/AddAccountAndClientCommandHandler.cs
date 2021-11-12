﻿using XBank.Domain.Core.CustomExceptions;
using XBank.Domain.Core.Entities;
using XBank.Domain.Core.Requests;
using XBank.Domain.Core.Responses;
using XBank.Domain.Shared.Handlers;
using XBank.Domain.Shared.Interfaces;
using XBank.Domain.Shared.Util;

namespace XBank.Domain.Core.Commands
{
    public class AddAccountAndClientCommandHandler : CommandHandler<Client, AddClientRequest, AddAccountAndClientResponse>
    {
        public AddAccountAndClientCommandHandler(ICommandRepository<Client> repository) : base(repository)
        {
        }

        public override AddAccountAndClientResponse Handle(AddClientRequest request)
        {
            request.CPF = StringFormater.FormatCPF(request.CPF);
            if (!Validations.ValidateCPF(request.CPF))
            {
                throw new DomainException($"CPF {request.CPF} provided is invalid.", 400);
            }

            var isClientExist = _repository.Exists(client => client.CPF == request.CPF);

            if (isClientExist)
            {
                throw new DomainException($"Customer with CPF {request.CPF} already registered. Please use the update route.", 400);
            }

            var client = new Client()
            {
                Name = request.Name,
                CPF = request.CPF,
                Email = request.Email,
                Address = request.Address,
                Phone = request.Phone,
            };

            var account = new Account();

            client.Account = account;

            _repository.Add(client);
            _repository.Save();

            var response = new AddAccountAndClientResponse {
                AccountId = account.Id,
                ClientId = client.Id,
                CPF = client.CPF,
                Name = client.Name,
                CreatedAt = account.CreatedAt
            };

            return response;
        }
    }
}
