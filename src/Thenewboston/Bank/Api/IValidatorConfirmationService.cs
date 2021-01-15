using System.Net.Http;
using System.Threading.Tasks;
using Thenewboston.Bank.Api.Models;
using Thenewboston.Common.Api.Models;
using Thenewboston.Common.Models;

namespace Thenewboston.Bank.Api
{
    public interface IValidatorConfirmationService
    {
        public Task<PaginatedResponseModel<Models.ValidatorConfirmation>> GetValidatorConfirmationServicesAsync(
            int offset,
            int limit);
    }
}