using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Thenewboston.Bank.Models
{
    internal class ConnectionRequest
    {
        [JsonProperty(PropertyName = "message")]
        public ConnectionRequestMessage Message { get; set; }

        [JsonProperty(PropertyName = "node_identifier")]
        public string NodeIdentifier { get; set; }

        [JsonProperty(PropertyName = "signature")]
        public string Signature { get; set; }
    }
}
