using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Thenewboston.Bank.Models
{
    internal class ConnectionRequestMessage
    {
        [JsonProperty(PropertyName = "ip_address")]
        public string IpAddress { get; set; }

        [JsonProperty(PropertyName = "port")]
        public int? Port { get; set; }

        [JsonProperty(PropertyName = "protocol")]
        public string Protocol { get; set; }
    }
}
