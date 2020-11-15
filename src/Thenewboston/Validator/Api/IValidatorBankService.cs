using System.Threading.Tasks;
using Thenewboston.Common.Api.Models;

namespace Thenewboston.Validator.Api
{
    public interface IValidatorBankService
    {
        Task<ResponseModel> GetBanksAsync();
    }
}
