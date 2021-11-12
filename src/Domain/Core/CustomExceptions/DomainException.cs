using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;

namespace XBank.Domain.Core.CustomExceptions
{
    public class DomainException : Exception
    {
        public DomainException(string message, int code)
            : base(message)
        {
            Code = code;
        }

        public DomainException(string message, List<ValidationFailure> errors, int code)
            : base(message)
        {
            Code = code;

            Errors = errors.Select(x => x.ErrorMessage);
        }

        public int Code { get; set; }
        public IEnumerable<string> Errors { get; set; }
}
}
