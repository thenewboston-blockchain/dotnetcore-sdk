using System.Threading.Tasks;
using Thenewboston.Common.Api.Models;
using Thenewboston.Validator.Api.Models;

namespace Thenewboston.Validator.Api
{
    internal interface IBankConfirmationService
    {
        public Task<PaginatedResponseModel<BankConfirmationServiceResponse>> GetBankConfirmationServicesAsync(
            int offset,
            int limit);
    }
}