using System.Collections.Generic;
using System.Threading.Tasks;
using Thenewboston.Validator.Models;

namespace Thenewboston.Validator.Api
{
    public interface IAccountsService
    {
        Task<IEnumerable<ValidatorAccount>> GetAccountsAsync();
        Task<ValidatorAccountBalance> GetAccountBalanceAsync(string accountNumber);
        Task<ValidatorAccountBalanceLock> GetAccountBalanceLockAsync(string accountNumber);
    }
}
