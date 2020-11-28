using System.Net.Http;
using System.Threading.Tasks;
using Thenewboston.Bank.Models;

namespace Thenewboston.Bank.Api
{
    public interface IUpgradeNoticeService
    {
        Task<HttpResponseMessage> PostUpgradeNoticeAsync(UpgradeNotice upgradeNotice); 
    }
}
