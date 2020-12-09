using Newtonsoft.Json;
using Thenewboston.Bank.Api;

namespace Thenewboston.Common.Models
{
    public class BankValidatorConfirmationService
    {
        [JsonProperty(PropertyName ="message")]
        public ValidatorConfirmationServiceMessage Message { get; set; }
        
        [JsonProperty(PropertyName ="node_identifier")]
        public string NodeIdentifier { get; set; }

        [JsonProperty(PropertyName ="signature")]
        public string Signature { get; set; }
    }
}