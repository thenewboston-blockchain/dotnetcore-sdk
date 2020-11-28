using System.Collections.Generic;
using Newtonsoft.Json;

namespace Thenewboston.Common.Models
{
    public class BlockMessage
    {
        [JsonProperty(PropertyName ="balance_key")]
        public string BalanceKey { get; set; }

        [JsonProperty(PropertyName ="txs")]
        public List<BlockTransaction> Transactions { get; set; }
    }
}