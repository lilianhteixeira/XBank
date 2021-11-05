﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XBank.Domain.Core.Entities;
using XBank.Domain.Core.Requests;
using XBank.Domain.Core.Responses;
using XBank.Domain.Shared.Handlers;
using XBank.Domain.Shared.Interfaces;
using XBank.Domain.Shared.Util;
using XBank.Domain.Shared.ValueObjects;

namespace XBank.Domain.Core.Commands
{
    public class OpenAccountCommandHandler : CommandHandler<Client, AddClientRequest, OpenAccountResponse>
    {
        public OpenAccountCommandHandler(ICommandRepository<Client> repository) : base(repository)
        {
        }

        public override OpenAccountResponse Handle(AddClientRequest request)
        {
            request.CPF = StringFormater.FormatCPF(request.CPF);
            if (!Validations.ValidateCPF(request.CPF))
            {
                throw new InvalidOperationException($"CPF {request.CPF} provided is invalid.");
            }

            var isClientExist = _repository.Exists(client => client.CPF == request.CPF);

            if (isClientExist)
            {
                throw new InvalidOperationException($"Customer with CPF {request.CPF} already registered. Please use the update route.");
            }

            var client = new Client()
            {
                Name = request.Name,
                //CPF = new CPF(request.CPF),
                CPF = request.CPF,
                Email = request.Email,
                Address = request.Address,
                Phone = request.Phone,
            };

            var account = new Account();

            client.Account = account;

            _repository.Add(client);
            _repository.Save();

            var response = new OpenAccountResponse {
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
