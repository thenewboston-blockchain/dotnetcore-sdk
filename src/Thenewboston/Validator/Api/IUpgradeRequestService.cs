using System.Net.Http;
using System.Threading.Tasks;
using Thenewboston.Validator.Models;

namespace Thenewboston.Validator.Api
{
    public interface IUpgradeRequestService
    {
        public Task<HttpResponseMessage> PostUpgradeRequestAsync(UpgradeRequest upgradeRequest);
    }
}
