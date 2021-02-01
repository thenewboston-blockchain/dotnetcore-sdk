namespace Thenewboston.Bank.Api.Models
{
    internal class RequestModel
    {
        public Message Message { get; set; }

        public string NodeIdentifier { get; set; }

        public string Signature { get; set; }
    }
}
