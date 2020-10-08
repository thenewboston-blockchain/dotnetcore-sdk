using System;
namespace Thenewboston.Bank.Models
{
    public class BankConfirmationService
    {
        public string Id { get; set; }

        public DateTime Created { get; set; }

        public DateTime Modified { get; set; }

        public DateTime Start { get; set; }

        public DateTime End { get; set; }

        public string Validator { get; set; }
    }
}
