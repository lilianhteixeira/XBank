using System;
using XBank.Domain.Core.Entities;
using XBank.Domain.Core.Requests;
using XBank.Domain.Shared.Handlers;
using XBank.Domain.Shared.Interfaces;
using XBank.Domain.Shared.Util;

namespace XBank.Domain.Core.Commands
{
    public class AddMovementCommandHandler : CommandHandler<Account, AddMovementRequest, object>
    {
        public AddMovementCommandHandler(ICommandRepository<Account> repository) : base(repository)
        {
        }

        public override object Handle(AddMovementRequest request)
        {
            var isClientExist = _repository.Exists(client => client.Id == request.GetAccountId());

            if (!isClientExist)
            {
                throw new InvalidOperationException($"Customer with Id {request.GetAccountId()} doesn't exist.");
            }

            var client = _repository.Get(x => x.Id == request.GetAccountId(), "Account");

            request.CPFSend = StringFormater.FormatCPF(request.CPFSend);
            if (!Validations.ValidateCPF(request.CPFSend))
            {
                throw new InvalidOperationException($"CPF {request.CPFSend} provided is invalid.");
            }

            var isCPFDestination = _repository.Exists(account => account.Client.CPF == request.CPFSend);

            return null;
        }
    }
}
