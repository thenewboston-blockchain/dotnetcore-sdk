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
        Task<ValidatorAccountBalance> GetAccountBalance(string accountNumber);
        Task<ValidatorAccountBalanceLock> GetAccountBalanceLock(string accountNumber);
    }
}
