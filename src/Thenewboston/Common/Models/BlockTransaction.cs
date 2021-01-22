using System.Numerics;
using Newtonsoft.Json;

namespace Thenewboston.Common.Models
{
    public class BlockTransaction
    {
        [JsonProperty(PropertyName ="amount")]
        public BigDecimal Amount { get; set; }

        [JsonProperty(PropertyName ="recipient")]
        public string Recipient { get; set; }
    }
}