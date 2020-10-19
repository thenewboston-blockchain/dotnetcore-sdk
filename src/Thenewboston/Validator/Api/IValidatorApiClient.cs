using System;
using System.Collections.Generic;
using System.Numerics;
using System.Threading.Tasks;
using Thenewboston.Validator.Models;

namespace Thenewboston.Validator.Api
{
    public interface IValidatorApiClient
    {
        Task<IEnumerable<ValidatorAccount>> GetAccountsAsync();
        Task<ValidatorAccountBalance> GetAccountBalanceAsync(string accountNumber);
        Task<ValidatorAccountBalanceLock> GetAccountBalanceLockAsync(string accountNumber);
    }
}
