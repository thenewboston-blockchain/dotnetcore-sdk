using Newtonsoft.Json;

namespace Thenewboston.Validator.Models
{
    public class PrimaryValidatorUpdatedMessage
    {
        [JsonProperty(PropertyName ="ip_address")]
        public string IPAddress { get; set; }

        [JsonProperty(PropertyName ="port")]
        public int? Port { get; set; }

        [JsonProperty(PropertyName ="protocol")]
        public string Protocol { get; set; }
    }
}
