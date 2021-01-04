using System.Net.Http;
using System.Threading.Tasks;
using Thenewboston.Validator.Models;

namespace Thenewboston.Validator.Api
{
    public interface IBankBlockService
    {
        public Task<HttpResponseMessage> PostBankBlockAsync(ValidatorBankBlock block); 
    }
}