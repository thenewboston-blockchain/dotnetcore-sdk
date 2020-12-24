using System.Collections.Generic;
using System.Threading.Tasks;
using Thenewboston.Common.Api.Models;
using Thenewboston.Validator.Models;

namespace Thenewboston.Validator.Api
{
    public interface IAccountsService
    {
        Task<PaginatedResponseModel<ValidatorAccount>> GetAccountsAsync();
        Task<ValidatorAccountBalance> GetAccountBalanceAsync(string accountNumber);
        Task<ValidatorAccountBalanceLock> GetAccountBalanceLockAsync(string accountNumber);
    }
}
