using System.Threading.Tasks;
using Thenewboston.Bank.Models;

namespace Thenewboston.Bank.Api
{
    internal interface IConfigService
    {
        Task<BankConfig> GetBankConfigAsync();
    }
}
