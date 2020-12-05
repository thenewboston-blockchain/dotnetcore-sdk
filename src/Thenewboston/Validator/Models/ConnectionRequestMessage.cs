using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Thenewboston.Validator.Models
{
    public class ConnectionRequestMessage
    {
        [JsonProperty(PropertyName = "ip_address")]
        public string IpAddress { get; set; }

        [JsonProperty(PropertyName = "port")]
        public string Port { get; set; }

        [JsonProperty(PropertyName = "protocol")]
        public string Protocol { get; set; }
    }
}
