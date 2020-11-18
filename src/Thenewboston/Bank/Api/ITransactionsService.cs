using System.Collections.Generic;
using System.Threading.Tasks;
using Thenewboston.Bank.Models;

namespace Thenewboston.Bank.Api
{
    public interface ITransactionsService
    {
        Task<IEnumerable<BankTransaction>> GetAllTransactionsAsync();
    }
}