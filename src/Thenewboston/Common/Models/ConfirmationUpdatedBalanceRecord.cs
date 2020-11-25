using Newtonsoft.Json;

namespace Thenewboston.Common.Models
{
    public class ConfirmationUpdatedBalanceRecord

    {
        [JsonProperty(PropertyName ="account_number")]
        public string AccountNumber { get; set; }

        [JsonProperty(PropertyName ="balance")]
        public string Balance { get; set; }

        [JsonProperty(PropertyName ="balance_lock")]
        public string BalanceLock { get; set; }
    }
}
