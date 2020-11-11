using System.Threading.Tasks;
using Thenewboston.Bank.Models;

namespace Thenewboston.Bank.Api
{
    public interface IBankConfigService
    {
        Task<BankConfig> GetBankConfigAsync();
    }
}
