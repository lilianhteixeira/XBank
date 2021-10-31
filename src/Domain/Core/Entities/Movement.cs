using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XBank.Domain.Shared.Entities;

namespace XBank.Domain.Core.Entities
{
    class Movement : Entity
    {
        public Guid IdAccount { get; set; }
        public int MovementValue { get; set; }
        public string CPF { get; set; }
    }
}
