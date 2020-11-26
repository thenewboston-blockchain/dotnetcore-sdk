using System.Collections.Generic;
using Newtonsoft.Json;

namespace Thenewboston.Common.Models
{
    public class ConfirmationBankBlockMessage
    {
        [JsonProperty(PropertyName ="balance_key")]
        public string BalanceKey { get; set; }

        [JsonProperty(PropertyName ="txs")]
        public List<ConfirmationBankBlockTransaction> Transactions { get; set; }
    }
}
