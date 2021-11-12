using System;

namespace XBank.Domain.Core.Responses
{
    public class AddAccountAndClientResponse
    {
        public Guid AccountId { get; set; }
        public Guid ClientId { get; set; }
        public string CPF { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
