using System;
using Newtonsoft.Json;

namespace Thenewboston.Bank.Api.Models
{
    public class BankConfirmationBlockResponse
    {
        [JsonProperty(PropertyName = "Id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "created_date")]
        public DateTime CreatedDate { get; set; }

        [JsonProperty(PropertyName = "modified_date")]
        public DateTime ModifiedDate { get; set; }

        [JsonProperty(PropertyName = "block_identifier")]
        public string BlockIdentifier { get; set; }

        [JsonProperty(PropertyName = "block")]
        public string Block { get; set; }

        [JsonProperty(PropertyName = "validator")]
        public string Validator { get; set; }
    }
}
