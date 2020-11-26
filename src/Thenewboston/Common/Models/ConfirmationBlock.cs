using System.Collections.Generic;
using Newtonsoft.Json;

namespace Thenewboston.Common.Models
{
    public class ConfirmationBlock
    {
        [JsonProperty(PropertyName ="message")]
        public ConfirmationBlockMessage Message { get; set; }

        [JsonProperty(PropertyName ="block_identifier")]
        public string BlockIdentifier { get; set; }

        [JsonProperty(PropertyName ="updated_balances")]
        public List<ConfirmationUpdatedBalanceRecord> UpdatedBalances { get; set; }

        [JsonProperty(PropertyName ="node_identifier")]
        public string NodeIdentifier { get; set; }

        [JsonProperty(PropertyName ="signature")]
        public string Signature { get; set; }
    }
}
