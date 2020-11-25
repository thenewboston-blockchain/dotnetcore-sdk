using System.Net.Http;
using System.Threading.Tasks;
using Thenewboston.Common.Api.Models;
using Thenewboston.Common.Models;

namespace Thenewboston.Bank.Api
{
    public interface IBankConfirmationBlockService
    {
        public Task<PaginatedResponseModel> GetAllBankConfirmationBlocksAsync();
        public Task<HttpResponseMessage> PostConfirmationBlockAsync(ConfirmationBlock confirmationBlock); 
    }
}
