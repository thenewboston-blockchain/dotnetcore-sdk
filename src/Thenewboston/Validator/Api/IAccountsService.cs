using System.Collections.Generic;
using System.Threading.Tasks;
using Thenewboston.Common.Api.Models;
using Thenewboston.Validator.Models;

namespace Thenewboston.Validator.Api
{
    internal interface IAccountsService
    {
        Task<PaginatedResponseModel<ValidatorAccount>> GetAccountsAsync(int offset, int limit);
        Task<ValidatorAccountBalance> GetAccountBalanceAsync(string accountNumber);
        Task<ValidatorAccountBalanceLock> GetAccountBalanceLockAsync(string accountNumber);
    }
}
