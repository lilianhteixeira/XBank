using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XBank.Domain.Shared.Requests;
using XBank.Domain.Shared.ValueObjects;

namespace XBank.Domain.Shared.Requests
{
    public class ClientRequest : Request
    {
        private Guid _id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }

        public Guid GetId() => _id;
        public void SetId(Guid id) => _id = id;
    }
}
