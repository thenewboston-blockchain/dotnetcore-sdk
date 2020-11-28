using System;
using Newtonsoft.Json;

namespace Thenewboston.Bank.Models
{
    public class BankBlock
    {
        [JsonProperty(PropertyName ="id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName ="created_date")]
        public DateTime Created { get; set; }

        [JsonProperty(PropertyName ="modified_date")]
        public DateTime Modified { get; set; }
        
        [JsonProperty(PropertyName ="balance_key")]
        public string BalanceKey { get; set; }
        
        [JsonProperty(PropertyName ="sender")]
        public string Sender { get; set; }
        
        [JsonProperty(PropertyName ="signature")]
        public string Signature { get; set; }
    }
}
