using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XBank.Domain.Shared.Requests
{
    public class GetByIdRequest : Request
    {
        private Guid _id { get; set; }

        public Guid GetId() => _id;
        public void SetId(Guid id) => _id = id;
    }
}
