using System;
using System.Collections.Generic;
using XBank.Domain.Core.Entities;
using XBank.Domain.Core.Enums;
using XBank.Domain.Core.Requests;
using XBank.Domain.Shared.Handlers;
using XBank.Domain.Shared.Interfaces;
using XBank.Domain.Shared.Util;

namespace XBank.Domain.Core.Commands
{
    public class AddAccountMovementCommandHandler : CommandHandler<Account, AddMovementRequest, object>
    {
        private readonly ICommandRepository<Movement> _movementRepository;

        public AddAccountMovementCommandHandler(
            ICommandRepository<Account> accountRepository, 
            ICommandRepository<Movement> movementRepository) : base(accountRepository)
        {
            _movementRepository = movementRepository;
        }

        public override object Handle(AddMovementRequest request)
        {
            var isAccountExist = _repository.Exists(account => account.Id == request.GetAccountId());

            if (!isAccountExist)
            {
                throw new InvalidOperationException($"Account with Id {request.GetAccountId()} doesn't exist.");
            }

            var account = _repository.Get(account => account.Id == request.GetAccountId(), "Client");

            var movement = new Movement();
            movement.MovementValue = request.MovementValue;
            movement.Type = request.Type;
            movement.Account = account;

            if (request.Type == MovementEnum.Deposit)
            {
                account.Deposit(request.MovementValue);
                movement.Origin = "ATM";
            }
            else
            {
                request.CPFSend = StringFormater.FormatCPF(request.CPFSend);

                if (!Validations.ValidateCPF(request.CPFSend) && request.Type != MovementEnum.Withdraw)
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

                    var accountDestination = _repository.Get(account => account.Client.CPF == request.CPFSend, "Client");

                    accountDestination.Deposit(request.MovementValue);

                    var destinationMovement = new Movement()
                    {
                        Account = accountDestination,
                        MovementValue = request.MovementValue,
                        Origin = account.Client.CPF,
                        Type = MovementEnum.Deposit,
                        CPFSend = accountDestination.Client.CPF

                    };
                    _repository.Update(accountDestination);
                    _movementRepository.Add(destinationMovement);

                    movement.Origin = account.Client.CPF;

                }
                else if (request.Type == MovementEnum.ExternalTransfer)
                {
                    // Call the external API first and then make the transfer
                    movement.Origin = account.Client.CPF;
                }
                else
                {
                    // only withdraw
                    movement.Origin = "ATM";
                }


                account.Withdraw(request.MovementValue);
            }

            movement.CPFSend = request.Type == MovementEnum.ExternalTransfer || request.Type == MovementEnum.InternalTransfer
                ? request.CPFSend
                : account.Client.CPF;
            
            _movementRepository.Add(movement);
            _repository.Update(account);
            _repository.Save();

            return null;
        }
    }
}
