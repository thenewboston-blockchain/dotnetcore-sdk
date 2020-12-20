using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Thenewboston.Common.Http;
using Thenewboston.Validator.Api.Models;

namespace Thenewboston.Validator.Api
{
    public class UpgradeRequestService : IUpgradeRequestService
    {
        private readonly IHttpRequestSender _requestSender;

        public UpgradeRequestService(IHttpRequestSender requestSender)
        {
            _requestSender = requestSender;
        }

        /// <summary>
        /// Posts a new upgrade request to a confirmation validator requesting that it upgrade to a Primary Validator. 
        /// Requesting bank will pass a <see cref="UpgradeRequest"/>
        /// </summary>
        /// <param name="upgradeRequest"></param>
        /// <returns><see cref="HttpResponseMessage"/>NOTE: 200: Ok - Validator has accepted the upgrade request, 400: Bad Request - Validator has rejected the upgrade</returns>
        public async Task<HttpResponseMessage> PostUpgradeRequestAsync(UpgradeRequest upgradeRequest)
        {
            if(upgradeRequest is null)
            {
                // TODO: Create specific exception
                throw new Exception(); 
            }

            var httpContent = new StringContent(JsonConvert.SerializeObject(upgradeRequest), Encoding.UTF8, "application/json");
            var jsonString = await httpContent.ReadAsStringAsync();

            if (string.IsNullOrEmpty(jsonString))
            {
                // TODO: Create specific exception
                throw new Exception(); 
            }

            var response = await _requestSender.PostAsync("/upgrade_request/", httpContent);
            return response; 
        }
    }
}
