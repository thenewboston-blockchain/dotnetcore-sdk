using System.Collections.Generic;
using System.Threading.Tasks;
using Thenewboston.Bank.Api.Models;
using Thenewboston.Bank.Models;
using Thenewboston.Common.Api.Models;

namespace Thenewboston.Bank.Api
{
    internal interface IAccountsService
    {
        Task<PaginatedResponseModel<BankAccount>> GetAccountsAsync(int offset, int limit);
        Task<BankAccount> UpdateAccountAsync(string accountNumber, RequestModel account);
    }
}
