using System.Threading.Tasks;
using Thenewboston.Bank.Models;
using Thenewboston.Common.Api.Models;

namespace Thenewboston.Bank.Api.Models
{
    public interface IConnectedBanksService
    {
        Task<PaginatedResponseModel<BankNodeResponse>> GetBanksAsync(int offset, int limit);
        Task<BankNodeResponse> UpdateBankAsync(string nodeIdentifier, RequestModel payload);
    }
}
