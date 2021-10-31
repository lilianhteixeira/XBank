using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XBank.Domain.Core.Entities
{
    class Movement
    {
        public Guid IdAccount { get; set; }
        public int MovementValue { get; set; }
        public string CPF { get; set; }
    }
}
