using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XBank.Domain.Core.Entities;

namespace XBank.Domain.Core.Responses
{
    public class GetClientResponse
    {
        public Guid Id { get; set; }
        public bool IsActive { get; set; }
        public string Name { get; set; }
        public string CPF { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }

        public GetClientResponse(Client client)
        {
            Id = client.Id;
            IsActive = client.IsActive;
            Name = client.Name;
            CPF = client.CPF;
            Email = client.Email;
            Address = client.Address;
            Phone = client.Phone;
        }
    }
}
