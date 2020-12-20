using System;
using System.Numerics;

namespace Thenewboston.Validator.Models
{
    public class ValidatorAccount
    {
        public string Id { get; set; }

        public string AccountNumber { get; set; }

        public BigDecimal Balance { get; set; }

        public string BalanceLock { get; set; }
    }
}
