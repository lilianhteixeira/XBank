using FluentValidation.Results;
using System;
using System.Collections.Generic;
using XBank.Domain.Core.Entities;
using XBank.Domain.Shared.Responses;

namespace XBank.Domain.Core.Responses
{
    public class AddAccountAndClientResponse : Response
    {
        public Guid AccountId { get; set; }
        public Guid ClientId { get; set; }
        public DateTime CreatedAt { get; set; }

        public AddAccountAndClientResponse(Client client)
        {
            AccountId = client.Account.Id;
            ClientId = client.Id;
            CreatedAt = client.CreatedAt;
        }
    }
}
