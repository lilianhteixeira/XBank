using FluentValidation.Results;
using System;
using System.Collections.Generic;
using XBank.Domain.Shared.Responses;

namespace XBank.Domain.Core.Responses
{
    public class AddAccountAndClientResponse : Response
    {
        public Guid AccountId { get; set; }
        public Guid ClientId { get; set; }
        public string CPF { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
