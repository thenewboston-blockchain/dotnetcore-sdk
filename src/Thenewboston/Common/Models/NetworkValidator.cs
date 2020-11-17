using Newtonsoft.Json;
using System;
using System.Numerics;

namespace Thenewboston.Common.Models
{
    public class NetworkValidator : Node
    {
        [JsonProperty(PropertyName = "daily_confirmation_rate")]
        public decimal? DailyConfirmationRate { get; set; }

        [JsonProperty(PropertyName = "root_account_file")]
        public string RootAccountFile { get; set; }

        [JsonProperty(PropertyName = "root_account_file_hash")]
        public string RootAccountFileHash { get; set; }

        [JsonProperty(PropertyName = "seed_block_identifier")]
        public string SeedBlockIdentifier { get; set; }
    }
}
