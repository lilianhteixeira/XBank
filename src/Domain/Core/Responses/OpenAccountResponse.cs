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
        public Guid ClientId { get; set; }
        public string CPF { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
