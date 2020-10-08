using System;
namespace Thenewboston.Bank.Models
{
    public class BankTransaction
    {
        public string Id { get; set; }

        public string Block { get; set; }

        public string Sender { get; set; }

        public string Recipient { get; set; }

        public decimal Amount { get; set; }
    }
}
