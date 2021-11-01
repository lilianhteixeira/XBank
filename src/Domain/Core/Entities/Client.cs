using System;
using XBank.Domain.Shared.Entities;

namespace XBank.Domain.Core.Entities
{
    public class Client : Entity
    {
        public Account Account { get; set; }
        // public Guid AccountId { get; set; }
        public string Name { get; set; }
        public string CPF { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
    }
}
