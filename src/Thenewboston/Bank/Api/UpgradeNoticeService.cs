using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Thenewboston.Bank.Models;
using Thenewboston.Common.Http;

namespace Thenewboston.Bank.Api
{
    public class UpgradeNoticeService : IUpgradeNoticeService
    {
        IHttpRequestSender _requestSender; 

        public UpgradeNoticeService(IHttpRequestSender requestSender)
        {
            _requestSender = requestSender; 
        }

        public async Task<HttpResponseMessage> PostUpgradeNoticeAsync(UpgradeNotice upgradeNotice)
        {
            if(upgradeNotice is null)
            {
                // TODO: Create specific exception
                throw new Exception(); 
            }

            var httpContent = new StringContent(JsonConvert.SerializeObject(upgradeNotice));
            var jsonString = await new StringContent(JsonConvert.SerializeObject(upgradeNotice)).ReadAsStringAsync();

            if(string.IsNullOrEmpty(jsonString))
            {
                // TODO: Create specific exception
                throw new Exception(); 
            }

            var result = await _requestSender.PostAsync($"/upgrade_notice/{upgradeNotice.NodeIdentifier}", httpContent);
            return result; 
        }
    }
}
