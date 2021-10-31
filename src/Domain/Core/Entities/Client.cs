using System;
using XBank.Domain.Shared.Entities;

namespace XBank.Domain.Core.Entities
{
    public class Client : Entity
    {
        public Guid IdAccount { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string Email { get; set; }
        public string Endereço { get; set; }
        public string Telefone { get; set; }
    }
}
