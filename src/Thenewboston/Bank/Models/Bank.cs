using System;
using System.Collections.Generic;
using Thenewboston.Common.Models;

namespace Thenewboston.Bank.Models
{
    public class Bank
    {
        public string AccountNumber { get; set; }

        public string IpAddress { get; set; }

        public string Port { get; set; }

        public string Protocol { get; set; }

        public string Version { get; set; }

        public int TxFee { get; set; }

        public NodeType NodeType { get; set; }

        public List<BankAccount> Accounts { get; set; }

        public List<BankTransaction> Transactions { get; set; }

        public List<BankBlock> Blocks { get; set; }

        public List<BlockInformation> Confirmations { get; set; }

        public List<BlockInformation> InvalidBlocks { get; set; }

        public List<BankNode> Banks { get; set; }

        public List<NetworkValidator> Validators { get; set; }

        public List<BankConfirmationService> ConfirmationServices { get; set; }
    }
}
