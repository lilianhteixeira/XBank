using System;

namespace XBank.Domain.Core.Entities
{
    public class Client
    {
        public Guid IdClient { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string Email { get; set; }
        public string Endereço { get; set; }
        public string Telefone { get; set; }
    }
}
