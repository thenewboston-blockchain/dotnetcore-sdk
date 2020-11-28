using System.Threading.Tasks;
using Thenewboston.Common.Api.Models;

namespace Thenewboston.Bank.Api
{
    public interface IBankConfirmationService
    {
        public Task<PaginatedResponseModel> GetValidatorConfirmationServicesAsync();

    }
}