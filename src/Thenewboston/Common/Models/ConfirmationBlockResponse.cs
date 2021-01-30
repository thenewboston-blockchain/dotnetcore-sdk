using System.Collections.Generic;
using Newtonsoft.Json;

namespace Thenewboston.Common.Models
{
    internal class ConfirmationBlockResponse
    {
        [JsonProperty(PropertyName ="block")]
        public ConfirmationBankBlock Block { get; set; }

        [JsonProperty(PropertyName ="block_identifier")]
        public string BlockIdentifier { get; set; }

        [JsonProperty(PropertyName ="updated_balances")]
        public List<ConfirmationUpdatedBalanceRecord> UpdatedBalances { get; set; }
    }
}
