using System.Net.Http;
using System.Threading.Tasks;
using Thenewboston.Bank.Models;
using Thenewboston.Common.Api.Models;
using Block = Thenewboston.Common.Models.Block;

namespace Thenewboston.Bank.Api
{
    public interface IBlocksService
    {
        public Task<PaginatedResponseModel<BankBlock>> GetBlocksAsync();
        
        public Task<HttpResponseMessage> PostBlocksAsync(Block block);
    }
}