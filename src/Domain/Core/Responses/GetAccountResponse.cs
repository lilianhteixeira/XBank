using System;
using XBank.Domain.Core.Entities;

namespace XBank.Domain.Core.Responses
{
    public class GetAccountResponse
    {
        public string ClientName { get; set; }
        public decimal Balance { get; private set; }
        public DateTime Date { get; set; }
        public Guid Id { get; set; }

        public GetAccountResponse(Account account)
        {
            Date = account.CreatedAt;
            ClientName = account.Client.Name;
            Balance = account.Balance;
            Id = account.Id;
        }
    }
}
