using System.Threading.Tasks;
using Thenewboston.Validator.Models;

namespace Thenewboston.Validator.Api
{
    public interface IConfigService
    {
        Task<ValidatorConfig> GetValidatorConfigAsync();
    }
}
