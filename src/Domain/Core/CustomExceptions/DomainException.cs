using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XBank.Domain.Core.CustomExceptions
{
    public class DomainException : Exception
    {
        public DomainException(string message, int code)
            : base(message)
        {
            Code = code;
        }

        public int Code { get; set; }

    }
}
