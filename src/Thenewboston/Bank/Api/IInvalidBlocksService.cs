  
using System.Threading.Tasks;
using Thenewboston.Bank.Api.Models;
using Thenewboston.Bank.Models;
using Thenewboston.Common.Api.Models;

namespace Thenewboston.Bank.Api
{
    internal interface IInvalidBlocksService
    {
        Task<PaginatedResponseModel<BankInvalidBlock>> GetInvalidBankBlocksAsync(int offset, int limit);        
    }
}