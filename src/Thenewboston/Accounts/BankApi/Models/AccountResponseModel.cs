using System;
namespace Thenewboston.Accounts.BankApi.Models
{
    public class AccountResponseModel
    {
        public string Id { get; set; }

        public string AccountNumber { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime ModifiedDate { get; set; }

        public double Trust { get; set; }
    }
}
