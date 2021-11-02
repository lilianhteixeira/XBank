using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XBank.Domain.Shared.Requests
{
    public class GetByIdRequest : Request
    {
        public Guid Id { get; set; }
    }
}
