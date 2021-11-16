using System;
using XBank.Domain.Core.Entities;
using XBank.Domain.Core.Enums;

namespace XBank.Domain.Core.Responses
{
    public class GetAccountMovementsResponse
    {
        public Guid Id { get; set; }
        public decimal MovementValue { get; set; }
        public string CPFSend { get; set; }
        public string Origin { get; set; }
        public string Type { get; set; }
        public DateTime CreatedAt { get; set; }

        public GetAccountMovementsResponse(Movement movement)
        {
            Id = movement.Id;
            MovementValue = movement.MovementValue;
            CPFSend = movement.CPFSend;
            Origin = movement.Origin;
            Type = Enum.GetName(typeof(MovementEnum), movement.Type);
            CreatedAt = movement.CreatedAt;
        }
    }
}
