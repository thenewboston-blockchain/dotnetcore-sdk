using System;
using System.Numerics;

namespace Thenewboston.Common.Models
{
    public class ValidatorNode : Node
    {
        public BigDecimal DailyRate { get; set; }

        public string RootAccountFile { get; set; }

        public string RootAccountFileHash { get; set; }

        public string SeedBlockIdentifier { get; set; }
    }
}
