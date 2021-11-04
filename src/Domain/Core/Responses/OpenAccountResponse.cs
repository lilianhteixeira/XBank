using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XBank.Domain.Core.Entities;
using XBank.Domain.Shared.ValueObjects;

namespace XBank.Domain.Core.Responses
{
    public class OpenAccountResponse
    {
        public Guid AccountId { get; set; }
        public CPF CPF { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
