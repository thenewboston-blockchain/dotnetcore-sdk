using Newtonsoft.Json;

namespace Thenewboston.Validator.Models
{
    public class PrimaryValidatorUpdatedResponse
    {
        [JsonProperty(PropertyName ="message")]
        public PrimaryValidatorUpdatedMessage Message { get; set; }

        [JsonProperty(PropertyName ="property_name")]
        public string NodeIdentifier { get; set; }

        [JsonProperty(PropertyName ="signature")]
        public string Signature { get; set; }
    }
}
