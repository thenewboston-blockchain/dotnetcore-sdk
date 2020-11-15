using System;

namespace Thenewboston.Bank.Api.Models
{
    public class RequestModel
    {
        public Message Message { get; set; }

        public string NodeIdentifier { get; set; }

        public string Signature { get; set; }
    }
}
