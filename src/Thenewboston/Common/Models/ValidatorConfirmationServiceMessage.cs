using System;
using Newtonsoft.Json;

namespace Thenewboston.Common.Models
{
    internal class ValidatorConfirmationServiceMessage
    {
        [JsonProperty(PropertyName = "start")] 
        
        public DateTime Start { get; set; }

        [JsonProperty(PropertyName = "end")] 
        
        public DateTime End { get; set; }
    }
}