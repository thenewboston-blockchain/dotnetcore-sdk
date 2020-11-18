using System.Collections.Generic;
using System.Threading.Tasks;
using Thenewboston.Bank.Models;

namespace Thenewboston.Bank.Api
{
    public interface IBankTransactions
    {
        Task<IEnumerable<BankTransaction>> GetAllTransactionsAsync();
    }
}