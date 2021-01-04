using Newtonsoft.Json;

namespace Thenewboston.Common.Models
{
    public class Block
    {
        [JsonProperty(PropertyName ="account_number")]
        public string AccountNumber { get; set; }
        
        [JsonProperty(PropertyName ="message")]
        public BlockMessage Message { get; set; }
        
        [JsonProperty(PropertyName ="signature")]
        public string Signature { get; set; }
    }
}