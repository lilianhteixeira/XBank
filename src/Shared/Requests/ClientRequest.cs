namespace XBank.Domain.Shared.Requests
{
    public class ClientRequest : GetByIdRequest
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
    }
}
