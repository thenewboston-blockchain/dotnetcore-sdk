using System.Net.Http;
using System.Threading.Tasks;
using Thenewboston.Bank.Api.Models;
using Thenewboston.Bank.Models;
using Thenewboston.Common.Api.Models;

namespace Thenewboston.Bank.Api
{
    internal interface IBlocksService
    {
        public Task<PaginatedResponseModel<BankBlock>> GetBlocksAsync(int offset, int limit);
        
        public Task<BankBlock> PostBlocksAsync(Thenewboston.Common.Models.Block block);
    }
}