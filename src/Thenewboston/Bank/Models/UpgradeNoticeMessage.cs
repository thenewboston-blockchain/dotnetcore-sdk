using Newtonsoft.Json;

namespace Thenewboston.Bank.Models
{
    public class UpgradeNoticeMessage
    {
        [JsonProperty(PropertyName = "bank_node_identifier")]
        public string BankNodeIdentifier { get; set; }
    }
}
