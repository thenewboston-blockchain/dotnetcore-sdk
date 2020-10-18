using System;
namespace Thenewboston.Common.Models
{
    public abstract class Node
    {
        public string NetworkId { get; set; }

        public string AccountNumber { get; set; }

        public int TxFee { get; set; }

        public string Protocol { get; set; }

        public string IpAddress { get; set; }

        public string Port { get; set; }

        public float Trust { get; set; }

        public string Version { get; set; }
    }
}
