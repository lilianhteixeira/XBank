using System;

namespace XBank.Domain.Core.Responses
{
    public class UpdateClientResponse
    {
        public string Name { get; set; }
        public string CPF { get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool isActive { get; set; }
    }
}
