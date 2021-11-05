using XBank.Domain.Shared.Requests;

namespace XBank.Domain.Core.Requests
{
    public class AddClientRequest : ClientRequest
    {
        public string CPF { get; set; }
    }
}
