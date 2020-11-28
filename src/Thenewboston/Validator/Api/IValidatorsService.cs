using System.Threading.Tasks;
using Thenewboston.Common.Api.Models;
using Thenewboston.Validator.Models;

namespace Thenewboston.Validator.Api
{
    public interface IValidatorsService
    {
        Task<PaginatedResponseModel<ValidatorResponseModel>> GetAllValidatorsAsync();
    }
}
