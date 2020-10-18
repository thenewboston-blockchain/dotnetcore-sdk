using System;
using System.Numerics;

namespace Thenewboston.Accounts.Models
{
    public class Account
    {
        public string Id { get; set; }

        public string AccountNumber { get; set; }

        public string NickName { get; set; }

        public string SigningKey { get; set; }

        public BigDecimal Balance { get; set; }

        public string BalanceLock { get; set; }
    }
}
