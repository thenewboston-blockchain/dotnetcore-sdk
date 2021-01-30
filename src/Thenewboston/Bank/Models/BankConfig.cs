using Newtonsoft.Json;
using Thenewboston.Common.Models;

namespace Thenewboston.Bank.Models
{
    public class BankConfig : Node
    {
        [JsonProperty(PropertyName = "primary_validator")]
        public ValidatorNode PrimaryValidator { get; set; }

        [JsonProperty(PropertyName = "node_type")]
        public NodeType NodeType { get; set; }
    }
}
