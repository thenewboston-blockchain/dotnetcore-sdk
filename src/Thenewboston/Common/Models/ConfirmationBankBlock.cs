using Newtonsoft.Json;

namespace Thenewboston.Common.Models
{
    public class ConfirmationBankBlock
    {
        [JsonProperty(PropertyName ="account_number")]
        public string AccountNumber { get; set; }

        [JsonProperty(PropertyName ="message")]
        public ConfirmationBankBlockMessage Message { get; set; }

        [JsonProperty(PropertyName ="signature")]
        public string Signature { get; set; }
    }
}
