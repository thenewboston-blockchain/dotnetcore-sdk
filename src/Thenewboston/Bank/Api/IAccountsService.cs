using System.Collections.Generic;
using System.Threading.Tasks;
using Thenewboston.Bank.Api.Models;
using Thenewboston.Bank.Models;
using Thenewboston.Common.Api.Models;

namespace Thenewboston.Bank.Api
{
    public interface IAccountsService
    {
        Task<PaginatedResponseModel<BankAccount>> GetAccountsAsync();
        Task<BankAccount> UpdateAccountAsync(string accountNumber, RequestModel account);
    }
}
