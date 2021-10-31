using System;
using System.Collections.Generic;

namespace XBank.Domain.Core.Entities
{
    public class Account
    {
        public Guid IdClient { get; set; }
        public decimal Balance { get; private set; }
        private List<Moviment> Moviment { get; set; }

        public List<string> GenerateExtract()
        {
            throw new NotImplementedException();
        }

        public void Transfer()
        {
            throw new NotImplementedException();
        }
        public void Withdraw()
        {
            throw new NotImplementedException();
        }
    }
}
