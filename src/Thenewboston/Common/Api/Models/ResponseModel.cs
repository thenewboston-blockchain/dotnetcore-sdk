using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Thenewboston.Common.Api.Models
{
    public class ResponseModel
    {
        [JsonProperty(PropertyName = "count")]
        public int Count { get; set; }

        [JsonProperty(PropertyName = "next")]
        public string Next { get; set; }
        
        [JsonProperty(PropertyName = "previous")]
        public string Previous { get; set; }

        [JsonProperty(PropertyName = "results")]
        public IEnumerable<object> Results { get; set; }
    }
}
