using Newtonsoft.Json;
using Thenewboston.Common.Models;

namespace Thenewboston.Validator.Models
{
    public class ValidatorBankBlock
    {
        [JsonProperty(PropertyName ="block")]
        public Block BankBlock { get; set; }
        
        [JsonProperty(PropertyName ="node_identifier")]
        public string NodeIdentifier { get; set; }

        [JsonProperty(PropertyName ="signature")]
        public string Signature { get; set; }
    }
}