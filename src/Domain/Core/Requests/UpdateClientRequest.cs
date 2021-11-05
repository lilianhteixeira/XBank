using XBank.Domain.Shared.Requests;

namespace XBank.Domain.Core.Requests
{
    public class UpdateClientRequest : ClientRequest
    {
        private bool _activate { get; set; }

        public bool GetActivate() => _activate;
        public void SetActivate(bool activate) => _activate = activate;
    }
}
