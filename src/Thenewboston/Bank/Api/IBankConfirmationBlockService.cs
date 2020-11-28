using System.Net.Http;
using System.Threading.Tasks;
using Thenewboston.Common.Api.Models;
using Thenewboston.Common.Models;
using BankConfirmationBlockResponse = Thenewboston.Bank.Models.BankConfirmationBlockResponse;

namespace Thenewboston.Bank.Api
{
    public interface IBankConfirmationBlockService
    {
        public Task<PaginatedResponseModel<BankConfirmationBlockResponse>> GetAllBankConfiramtionBlocksAsync();
        public Task<HttpResponseMessage> PostConfirmationBlockAsync(ConfirmationBlock confirmationBlock); 
    }
}
