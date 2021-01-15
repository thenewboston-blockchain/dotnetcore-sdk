using System.Net.Http;
using System.Threading.Tasks;
using Thenewboston.Bank.Api.Models;
using Thenewboston.Common.Api.Models;
using Thenewboston.Common.Models;

namespace Thenewboston.Bank.Api
{
    public interface IBankConfirmationBlockService
    {
        public Task<PaginatedResponseModel<BankConfirmationBlock>> GetAllBankConfiramtionBlocksAsync(int offset, int limit);
    }
}
