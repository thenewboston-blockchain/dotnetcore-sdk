using Newtonsoft.Json;

namespace Thenewboston.Bank.Models
{
    public class BankInvalidBlockRequest
    {
        [JsonProperty("message")]
        public InvalidBlockBankRequestMessage Message { get; set; }

        [JsonProperty("node_identifier")]
        public string NodeIdentifier { get; set; }

        [JsonProperty("signature")]
        public string Signature { get; set; }
    }
    
    public class InvalidBlockBankRequestMessage
    {
        [JsonProperty("block")]
        public Block Block { get; set; }

        [JsonProperty("block_identifier")]
        public string BlockIdentifier { get; set; }

        [JsonProperty("primary_validator_node_identifier")]
        public string PrimaryValidatorNodeIdentifier { get; set; }
    }

    public class Block
    {
        [JsonProperty("account_number")]
        public string AccountNumber { get; set; }

        [JsonProperty("message")]
        public BlockMessage Message { get; set; }

        [JsonProperty("signature")]
        public string Signature { get; set; }
    }

    public class BlockMessage
    {
        [JsonProperty("balance_key")]
        public string BalanceKey { get; set; }

        [JsonProperty("txs")]
        public BlockTransactions[] Txs { get; set; }
    }

    public class BlockTransactions
    {
        [JsonProperty("amount")]
        public double Amount { get; set; }

        [JsonProperty("recipient")]
        public string Recipient { get; set; }
    }
}