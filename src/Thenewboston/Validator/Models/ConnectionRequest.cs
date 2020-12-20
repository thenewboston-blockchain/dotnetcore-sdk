using Newtonsoft.Json;

namespace Thenewboston.Validator.Models
{
    public class ConnectionRequest
    {
        [JsonProperty(PropertyName = "message")]
        public ConnectionRequestMessage Message { get; set; }

        [JsonProperty(PropertyName = "node_identifier")]
        public string NodeIdentifier { get; set; }

        [JsonProperty(PropertyName = "signature")]
        public string Signature { get; set; }
    }
}
