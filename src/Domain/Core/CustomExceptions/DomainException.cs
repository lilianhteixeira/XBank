using System;

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
