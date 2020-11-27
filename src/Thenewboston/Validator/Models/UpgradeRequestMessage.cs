using Newtonsoft.Json;

namespace Thenewboston.Validator.Models
{
    public class UpgradeRequestMessage
    {
        [JsonProperty(PropertyName = "validator_node_identifier")]
        public string ValidatorNodeIdentifier { get; set; }
    }
}
