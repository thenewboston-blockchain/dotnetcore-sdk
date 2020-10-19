using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Thenewboston.Bank.Api.Models;
using Thenewboston.Bank.Models;

namespace Thenewboston.Bank.Api
{
    public interface IBankApiClient
    {
        Task<IEnumerable<BankAccount>> GetAccountsAsync();
        Task<BankAccount> UpdateAccountAsync(AccountRequestModel account);
    }
}
