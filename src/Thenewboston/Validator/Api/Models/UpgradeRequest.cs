using Newtonsoft.Json;

namespace Thenewboston.Validator.Api.Models
{
    public class UpgradeRequest
    {
        [JsonProperty(PropertyName ="message")]
        public UpgradeRequestMessage Message { get; set; }

        [JsonProperty(PropertyName ="node_identifier")]
        public string NodeIdentifier { get; set; }

        [JsonProperty(PropertyName ="signature")]
        public string Signature { get; set; }
    }
}
