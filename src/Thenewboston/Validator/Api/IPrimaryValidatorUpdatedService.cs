using System.Net.Http;
using System.Threading.Tasks;

namespace Thenewboston.Validator.Api
{
    public interface IPrimaryValidatorUpdatedService
    {
        Task<HttpResponseMessage> PostPrimaryValidatorUpdatedAsync(); 
    }
}
