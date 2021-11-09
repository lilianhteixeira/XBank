using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XBank.Domain.Core.Enums;
using XBank.Domain.Shared.Requests;

namespace XBank.Domain.Core.Requests
{
    public class AddMovementRequest : Request
    {
        private Guid _accountId { get; set; }
        public decimal MovementValue { get; set; }
        public string CPFSend { get; set; }
        public MovementEnum Type { get; set; }


        public Guid GetAccountId() => _accountId;
        public void SetAccountId(Guid id) => _accountId = id;
    }
}
