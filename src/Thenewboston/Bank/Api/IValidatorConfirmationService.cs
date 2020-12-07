using System.Threading.Tasks;
using Thenewboston.Common.Api.Models;

namespace Thenewboston.Bank.Api
{
    public interface IValidatorConfirmationService
    {
        public Task<PaginatedResponseModel> GetValidatorConfirmationServicesAsync();

    }
}