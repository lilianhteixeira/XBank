using System;
using System.Collections.Generic;
using XBank.Domain.Core.CustomExceptions;
using XBank.Domain.Shared.Entities;

namespace XBank.Domain.Core.Entities
{
    public class Account : Entity

    {
        public Guid ClientId { get; set; }
        public Client Client { get; set; }
        public decimal Balance { get; private set; }
        public List<Movement> Movements { get; set; }

        public List<string> GenerateExtract()
        {
            throw new NotImplementedException();
        }

        //public void Transfer()
        //{
        //    throw new NotImplementedException();
        //}
        public void Withdraw(decimal movementValue)
        {
            if (Balance < movementValue)
            {
                throw new DomainException("Insufficient balance.", 400);
            }

            Balance -= movementValue;
        }

        public void Deposit(decimal movementValue)
        {
            Balance += movementValue;
        }
    }
}
