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
        public string CPF { get; set; }

        public RemoveAccountRequest(string cpf)
        {
            CPF = cpf;
        }
    }
}
