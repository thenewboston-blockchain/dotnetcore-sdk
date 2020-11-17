using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Thenewboston.Common.Models
{
    public class ValidatorNode : NetworkValidator
    {
        [JsonProperty(PropertyName = "trust")]
        public decimal Trust { get; set; }
    }
}
