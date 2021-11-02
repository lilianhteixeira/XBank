using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XBank.Domain.Shared.Requests;

namespace XBank.Domain.Core.Requests
{
    public class ClientRequest : Request
    {
        public ClientRequest(string name, string cpf, string email, string address, string phone)
        {
            Name = name;
            CPF = cpf;
            Email = email;
            Address = address;
            Phone = phone;
        }

        public string Name { get; set; }
        public string CPF { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
    }
}
