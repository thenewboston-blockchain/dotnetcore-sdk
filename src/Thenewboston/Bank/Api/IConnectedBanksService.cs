using System.Threading.Tasks;
using Thenewboston.Bank.Models;
using Thenewboston.Common.Api.Models;

namespace Thenewboston.Bank.Api.Models
{
    public interface IConnectedBanksService
    {
        Task<PaginatedResponseModel<BankResponse>> GetBanksAsync();
        Task<BankResponse> UpdateBankAsync(string nodeIdentifier, RequestModel payload);
    }
}
