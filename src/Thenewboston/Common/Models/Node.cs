using Newtonsoft.Json;
using System;
namespace Thenewboston.Common.Models
{
    public abstract class Node
    {
        [JsonProperty(PropertyName = "node_identifier")]
        public string NodeIdentifier { get; set; }

        [JsonProperty(PropertyName = "account_number")]
        public string AccountNumber { get; set; }

        [JsonProperty(PropertyName = "default_transaction_fee")]
        public decimal? DefaultTransactionFee { get; set; }

        [JsonProperty(PropertyName = "protocol")]
        public string Protocol { get; set; }

        [JsonProperty(PropertyName = "ip_address")]
        public string IpAddress { get; set; }

        [JsonProperty(PropertyName = "port")]
        public int? Port { get; set; }   

        [JsonProperty(PropertyName = "version")]
        public string Version { get; set; }
    }
}
