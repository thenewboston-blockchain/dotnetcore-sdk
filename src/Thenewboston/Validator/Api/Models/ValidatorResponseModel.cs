using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Thenewboston.Validator.Api.Models
{
    public class ValidatorResponseModel
    {
        [JsonProperty(PropertyName = "node_identifier")]
        public string NodeIdentifier { get; set; }

        [JsonProperty(PropertyName = "account_number")]
        public string AccountNumber { get; set; }

        [JsonProperty(PropertyName = "default_transaction_fee")]
        public int DefaultTransactionFee { get; set; }

        [JsonProperty(PropertyName = "protocol")]
        public string Protocol { get; set; }

        [JsonProperty(PropertyName = "ip_address")]
        public string IpAddress { get; set; }

        [JsonProperty(PropertyName = "port")]
        public int? Port { get; set; }

        [JsonProperty(PropertyName = "version")]
        public string Version { get; set; }

        [JsonProperty(PropertyName = "daily_confirmation_rate")]
        public string DailyConfirmationRate { get; set; }

        [JsonProperty(PropertyName = "root_account_file")]
        public string RootAccountFile { get; set; }

        [JsonProperty(PropertyName = "root_account_file_hash")]
        public string RootAccountFileHash { get; set; }

        [JsonProperty(PropertyName = "seed_block_identifier")]
        public string SeedBlockIdentifier { get; set; }

        [JsonProperty(PropertyName = "trust")]
        public string Trust { get; set; }
    }
}
