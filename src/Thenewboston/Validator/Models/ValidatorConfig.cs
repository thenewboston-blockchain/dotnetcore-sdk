using Newtonsoft.Json;
using Thenewboston.Common.Models;

namespace Thenewboston.Validator.Models
{
    public class ValidatorConfig : NetworkValidator
    {
        [JsonProperty(PropertyName = "primary_validator")]
        public ValidatorNode PrimaryValidator { get; set; }

        [JsonProperty(PropertyName = "node_type")]
        public NodeType NodeType { get; set; }
    }
}
