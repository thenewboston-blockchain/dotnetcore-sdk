using System.Threading.Tasks;
using Thenewboston.Bank.Models;

namespace Thenewboston.Bank.Api
{
    public interface IConfigService
    {
        Task<BankConfig> GetBankConfigAsync();
    }
}
