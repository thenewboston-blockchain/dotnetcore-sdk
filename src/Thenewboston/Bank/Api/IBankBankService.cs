using System.Threading.Tasks;
using Thenewboston.Bank.Models;
using Thenewboston.Common.Api.Models;

namespace Thenewboston.Bank.Api.Models
{
    public interface IBankBankService
    {
        Task<ResponseModel> GetBanksAsync();
        Task<BankDTO> UpdateBankAsync(string nodeIdentifier, RequestModel payload);
    }
}
