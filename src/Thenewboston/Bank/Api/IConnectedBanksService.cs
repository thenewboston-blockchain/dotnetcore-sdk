using System.Threading.Tasks;
using Thenewboston.Bank.Models;
using Thenewboston.Common.Api.Models;

namespace Thenewboston.Bank.Api.Models
{
    internal interface IConnectedBanksService
    {
        Task<PaginatedResponseModel<BankNode>> GetBanksAsync(int offset, int limit);
        Task<BankNode> UpdateBankAsync(string nodeIdentifier, RequestModel payload);
    }
}
