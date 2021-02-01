using System.Threading.Tasks;
using Thenewboston.Common.Api.Models;
using Thenewboston.Validator.Models;

namespace Thenewboston.Validator.Api
{
    internal interface IConnectedBanksService
    {
        Task<PaginatedResponseModel<ValidatorBank>> GetBanksAsync(int offset, int limit);
    }
}
