using Newtonsoft.Json;

namespace Thenewboston.Common.Models
{
    public class BlockTransaction
    {
        [JsonProperty(PropertyName ="amount")]
        public string Amount { get; set; }

        [JsonProperty(PropertyName ="recipient")]
        public string Recipient { get; set; }
    }
}