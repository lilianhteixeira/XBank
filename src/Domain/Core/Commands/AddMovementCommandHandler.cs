using System;
using XBank.Domain.Core.Entities;
using XBank.Domain.Core.Enums;
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
            var isAccountExist = _repository.Exists(account => account.Id == request.GetAccountId());

            if (!isAccountExist)
            {
                throw new InvalidOperationException($"Account with Id {request.GetAccountId()} doesn't exist.");
            }

            var account = _repository.Get(account => account.Id == request.GetAccountId(), "Movements");

            var movement = new Movement();
            movement.MovementValue = request.MovementValue;
            movement.Type = request.Type;

            if (request.Type == MovementEnum.Deposit)
            {
                account.Deposit(request.MovementValue);
                movement.Account = account;
                movement.Origin = "ATM";
            }
            else
            {
                request.CPFSend = StringFormater.FormatCPF(request.CPFSend);

                if (!Validations.ValidateCPF(request.CPFSend))
                {
                    throw new InvalidOperationException($"CPF {request.CPFSend} provided is invalid.");
                }

                if (request.Type == MovementEnum.InternalTransfer)
                {
                    var isCPFDestinationExist = _repository.Exists(account => account.Client.CPF == request.CPFSend);

                    if (!isCPFDestinationExist)
                    {
                        throw new InvalidOperationException($"The requested CPF does not have an account with us.");
                    }


                    var accountDestination = _repository.Get(account => account.Client.CPF == request.CPFSend);

                    accountDestination.Deposit(request.MovementValue);

                }
                else if (request.Type == MovementEnum.ExternalTransfer)
                {
                    // Call the external API first and then make the transfer
                }

                account.Withdraw(request.MovementValue);
            }


            _repository.Save();
            return null;
        }
    }
}
