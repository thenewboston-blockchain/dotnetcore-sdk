using System.Collections.Generic;
using System.Threading.Tasks;
using Thenewboston.Bank.Models;
using Thenewboston.Common.Api.Models;

namespace Thenewboston.Bank.Api
{
    internal interface ITransactionsService
    {
        Task<PaginatedResponseModel<BankTransaction>> GetAllTransactionsAsync(int offset, int limit);
    }
}