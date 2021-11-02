using XBank.Domain.Shared.Requests;

namespace XBank.Domain.Core.Requests
{
    public class GetAllClientRequest : Request
    {
        public string Name { get; set; }
        public bool? Active { get; set; }
    }
}
