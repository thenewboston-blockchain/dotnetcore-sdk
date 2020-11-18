using System;
namespace Thenewboston.Bank.Models
{
    public class BankAccount
    {
        public string Id { get; set; }

        public string AccountNumber { get; set; }

        public string Trust { get; set; }

        public DateTime Created { get; set; }

        public DateTime Modified { get; set; }
    }
}
