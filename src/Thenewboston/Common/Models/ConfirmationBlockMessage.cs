using Newtonsoft.Json;

namespace Thenewboston.Common.Models
{
    public class ConfirmationBlockMessage
    {
        [JsonProperty(PropertyName = "block")]
        public ConfirmationBankBlock Block { get; set; }

        [JsonProperty(PropertyName ="signature")]
        public string Signature { get; set; }
    }
}
