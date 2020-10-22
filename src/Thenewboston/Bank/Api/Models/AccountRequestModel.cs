using System;

namespace Thenewboston.Bank.Api.Models
{
    public class AccountRequestModel
    {
        public Message Message { get; set; }

        public string NodeIdentifier { get; set; }

        public string Signature { get; set; }
    }

    public class Message
    {
        public double Trust { get; set; }
    }
}
