using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XBank.Domain.Core.Enums;
using XBank.Domain.Shared.Entities;

namespace XBank.Domain.Core.Entities
{
    public class Movement : Entity
    {
        public Account Account { get; set; }
        public Guid AccountId { get; set; }
        public int MovementValue { get; set; }
        public string CPFSend { get; set; }
        public MovementEnum Type { get; set; }
    }
}
