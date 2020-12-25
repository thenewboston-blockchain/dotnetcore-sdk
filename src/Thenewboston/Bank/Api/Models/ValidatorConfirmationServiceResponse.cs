using System;
using Newtonsoft.Json;

namespace Thenewboston.Bank.Api.Models
{
    public class ValidatorConfirmationServiceResponse
    {
        [JsonProperty(PropertyName = "id")] 
        
        public string Id { get; set; }

        [JsonProperty(PropertyName = "created_date")]
        
        public DateTime Created { get; set; }

        [JsonProperty(PropertyName = "modified_date")]
        
        public DateTime Modified { get; set; }

        [JsonProperty(PropertyName = "start")] 
        
        public DateTime Start { get; set; }

        [JsonProperty(PropertyName = "end")] 
        
        public DateTime End { get; set; }

        [JsonProperty(PropertyName = "validator")]
        
        public string Validator { get; set; }
    }
}