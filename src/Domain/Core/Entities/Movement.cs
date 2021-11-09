using System;
using XBank.Domain.Core.Enums;
using XBank.Domain.Shared.Entities;

namespace XBank.Domain.Core.Entities
{
    public class Movement : Entity
    {
        public Account Account { get; set; }
        public Guid AccountId { get; set; }
        public decimal MovementValue { get; set; }
        public string CPFSend { get; set; }
        public string Origin { get; set; }
        public MovementEnum Type { get; set; }
    }
}
