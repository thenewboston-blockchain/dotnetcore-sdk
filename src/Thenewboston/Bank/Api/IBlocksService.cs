using System.Net.Http;
using System.Threading.Tasks;
using Thenewboston.Common.Api.Models;
using Thenewboston.Common.Models;

namespace Thenewboston.Bank.Api
{
    public interface IBlocksService
    {
        public Task<PaginatedResponseModel> GetBlocksAsync();
        
        public Task<HttpResponseMessage> PostBlocksAsync(Block block);
    }
}