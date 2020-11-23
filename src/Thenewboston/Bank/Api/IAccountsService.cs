using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Thenewboston.Bank.Api.Models;
using Thenewboston.Bank.Models;

namespace Thenewboston.Bank.Api
{
    public interface IAccountsService
    {
        Task<IEnumerable<BankAccount>> GetAccountsAsync();
        Task<BankAccount> UpdateAccountAsync(string accountNumber, RequestModel account);
    }
}
