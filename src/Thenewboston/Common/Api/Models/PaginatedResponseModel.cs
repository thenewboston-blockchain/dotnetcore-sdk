using System.Collections.Generic;
using Newtonsoft.Json;

namespace Thenewboston.Common.Api.Models
{
    public class PaginatedResponseModel<T>
    {
        [JsonProperty(PropertyName = "count")]
        public int Count { get; set; }

        [JsonProperty(PropertyName = "next")]
        public string Next { get; set; }
        
        [JsonProperty(PropertyName = "previous")]
        public string Previous { get; set; }

        [JsonProperty(PropertyName = "results")]
        public IEnumerable<T> Results { get; set; }
    }
}
