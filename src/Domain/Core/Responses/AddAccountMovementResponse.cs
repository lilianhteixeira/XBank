using System;
using XBank.Domain.Core.Entities;

namespace XBank.Domain.Core.Responses
{
    public class AddAccountMovementResponse
    {

        public DateTime CreatedAt { get; set; }
        public Guid Id { get; set; }

        public AddAccountMovementResponse(Movement movement)
        {
            CreatedAt = movement.CreatedAt;
            Id = movement.Id;
        }
    }
}
