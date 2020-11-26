using System.Threading.Tasks;
using Thenewboston.Bank.Models;
using Thenewboston.Common.Api.Models;

namespace Thenewboston.Bank.Api
{
    public interface IInvalidBlocksService
    {
        Task<PaginatedResponseModel<BankInvalidBlock>> GetInvalidBankBlocksAsync(PaginationParams pagination = default);
        Task<BankInvalidBlock> SendInvalidBlocksToBankAsync(BankInvalidBlockRequest model);
        
    }
}