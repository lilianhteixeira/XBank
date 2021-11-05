using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XBank.Domain.Shared.Requests;

namespace XBank.Domain.Core.Requests
{
    public class RemoveAccountRequest : Request

    {
        private Guid _id { get; set; }

        public Guid GetId() => _id;
        public void SetId(Guid id) => _id = id;

    }
}
