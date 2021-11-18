using System;
using XBank.Domain.Core.Entities;

namespace XBank.Domain.Core.Responses
{
    public class UpdateClientResponse
    {
        public DateTime UpdatedAt { get; set; }
        public bool isActive { get; set; }

        public UpdateClientResponse(Client client)
        {
            UpdatedAt = client.UpdatedAt;
            isActive = client.IsActive;
        }
    }
}
