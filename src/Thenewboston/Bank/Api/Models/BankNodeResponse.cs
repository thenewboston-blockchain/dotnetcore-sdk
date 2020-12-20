using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Thenewboston.Common.Models;

namespace Thenewboston.Bank.Api.Models
{
    public class BankNodeResponse
    {
        [JsonProperty(PropertyName = "account_number")]
        public string AccountNumber { get; set; }

        [JsonProperty(PropertyName = "ip_address")]
        public string IpAddress { get; set; }

        [JsonProperty(PropertyName = "node_identifier")]
        public string NodeIdentifier { get; set; }

        [JsonProperty(PropertyName = "port")]
        public int? Port { get; set; }

        [JsonProperty(PropertyName = "protocol")]
        public string Protocol { get; set; }

        [JsonProperty(PropertyName = "version")]
        public string Version { get; set; }

        [JsonProperty(PropertyName = "default_transaction_fee")]
        public int DefaultTransactionFee { get; set; }

        [JsonProperty(PropertyName = "trust")]
        public string Trust { get; set; }
    }
}
