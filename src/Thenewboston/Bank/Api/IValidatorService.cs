using System.Threading.Tasks;
using Thenewboston.Bank.Api.Models;
using Thenewboston.Bank.Models;
using Thenewboston.Common.Api.Models;

namespace Thenewboston.Bank.Api
{
    internal interface IValidatorService
    {
        Task<PaginatedResponseModel<BankValidator>> GetAllValidatorsAsync(int offset, int limit);

        Task<BankValidator> PatchValidatorAsync(string nodeIdentifier, RequestModel trust);

    }
}
