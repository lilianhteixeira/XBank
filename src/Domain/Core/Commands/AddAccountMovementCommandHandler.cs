using System.Linq;
using XBank.Domain.Core.CustomExceptions;
using XBank.Domain.Core.Entities;
using XBank.Domain.Core.Enums;
using XBank.Domain.Core.Requests;
using XBank.Domain.Core.Responses;
using XBank.Domain.Core.Validators;
using XBank.Domain.Shared.Handlers;
using XBank.Domain.Shared.Interfaces;
using XBank.Domain.Shared.Util;

namespace XBank.Domain.Core.Commands
{
    public class AddAccountMovementCommandHandler : CommandHandler<Account, AddMovementRequest, AddAccountMovementResponse>
    {
        private readonly ICommandRepository<Movement> _movementRepository;

        public AddAccountMovementCommandHandler(
            ICommandRepository<Account> accountRepository, 
            ICommandRepository<Movement> movementRepository) : base(accountRepository)
        {
            _movementRepository = movementRepository;
        }

        public override AddAccountMovementResponse Handle(AddMovementRequest request)
        {
            var validator = new AddMovementRequestValidator();

            var validatorResult = validator.Validate(request);

            if (validatorResult.Errors.Any())
            {
                throw new DomainException($"Validation Error", validatorResult.Errors, 400);
            }

            var isAccountExist = _repository.Exists(account => account.Id == request.GetAccountId());

            if (!isAccountExist)
            {
                throw new DomainException($"Account with Id {request.GetAccountId()} doesn't exist.", 400);
            }

            var account = _repository.Get(account => account.Id == request.GetAccountId(), "Client");

            if (!account.IsActive)
            {
                throw new DomainException($"You must activate the account before editing.", 400);
            }

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

                if (!Validations.ValidateCPF(request.CPFSend) && request.Type != MovementEnum.Withdraw)
                {
                    throw new DomainException($"CPF {request.CPFSend} provided is invalid or enter the CPF numbers only", 400);
                }

                if (request.Type == MovementEnum.InternalTransfer)
                {
                    var isCPFDestinationExist = _repository.Exists(account => account.Client.CPF == request.CPFSend);

                    if (!isCPFDestinationExist)
                    {
                        throw new DomainException($"The requested CPF does not have an account with us.", 404);
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

            return new AddAccountMovementResponse { Id = movement.Id, CreatedAt = movement.CreatedAt };
        }
    }
}
