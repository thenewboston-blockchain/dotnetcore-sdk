using System.Threading.Tasks;
using Thenewboston.Validator.Models;

namespace Thenewboston.Validator.Api
{
    internal interface IConfigService
    {
        Task<ValidatorConfig> GetValidatorConfigAsync();
    }
}
