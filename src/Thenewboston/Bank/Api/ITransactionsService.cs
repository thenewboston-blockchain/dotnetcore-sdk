using System.Collections.Generic;
using System.Threading.Tasks;
using Thenewboston.Bank.Models;
using Thenewboston.Common.Api.Models;

namespace Thenewboston.Bank.Api
{
    public interface ITransactionsService
    {
        Task<PaginatedResponseModel<BankTransaction>> GetAllTransactionsAsync();
    }
}