using System;
using Newtonsoft.Json;

namespace Thenewboston.Bank.Models
{
    internal class BankInvalidBlock
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("created_date")]
        public DateTime Created { get; set; }

        [JsonProperty("modified_date")]
        public DateTime Modified { get; set; }

        [JsonProperty("block_identifier")]
        public string BlockIdentifier { get; set; }

        [JsonProperty("block")]
        public string Block { get; set; }

        [JsonProperty("confirmation_validator")]
        public string ConfirmationValidator { get; set; }

        [JsonProperty("primary_validator")]
        public string PrimaryValidator { get; set; }
    }

}