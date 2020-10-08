using System;
namespace Thenewboston.Bank.Models
{
    public class BankBlock
    {
        public string Id { get; set; }

        public string BalanceKey { get; set; }

        public string Sender { get; set; }

        public string Signature { get; set; }

        public DateTime Created { get; set; }

        public DateTime Modified { get; set; }
    }
}
