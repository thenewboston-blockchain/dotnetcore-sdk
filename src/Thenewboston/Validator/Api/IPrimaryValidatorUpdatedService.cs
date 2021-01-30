using System.Net.Http;
using System.Threading.Tasks;
using Thenewboston.Validator.Models;

namespace Thenewboston.Validator.Api
{
    internal interface IPrimaryValidatorUpdatedService
    {
        Task<HttpResponseMessage> PostPrimaryValidatorUpdatedAsync(PrimaryValidatorUpdatedModel validatorUpdatedModel); 
    }
}
