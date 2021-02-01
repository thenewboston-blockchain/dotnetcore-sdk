using Newtonsoft.Json.Converters;
using System;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Thenewboston.Common.Models
{
    public enum NodeType
    {
        Bank,
        Validator,
        [EnumMember(Value = "PRIMARY_VALIDATOR")]
        PrimaryValidator,
        [EnumMember(Value = "CONFIRMATION_VALIDATOR")]
        ConfirmationValidator
    }
}
