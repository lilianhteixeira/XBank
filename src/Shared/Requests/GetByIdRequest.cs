using System;

namespace XBank.Domain.Shared.Requests
{
    public class GetByIdRequest : Request
    {
        private Guid _id { get; set; }

        public Guid GetId() => _id;
        public void SetId(Guid id) => _id = id;
    }
}
