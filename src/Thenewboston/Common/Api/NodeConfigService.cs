using Newtonsoft.Json;
using System;
using System.Threading.Tasks;
using Thenewboston.Common.Api;
using Thenewboston.Common.Http;

namespace Thenewboston.Validator.Api
{
    public class NodeConfigService : INodeConfigService
    {

        private readonly IHttpRequestSender _requestSender;

        public NodeConfigService(IHttpRequestSender requestSender)
        {
            _requestSender = requestSender;
        }

        public async Task<T> GetConfigAsync<T>()
        {
            var response = await _requestSender.GetAsync("/config");

            if (!response.IsSuccessStatusCode)
            {
                //TODO: create specific exception
                throw new Exception();
            }

            var stringResult = await response.Content.ReadAsStringAsync();

            if (string.IsNullOrEmpty(stringResult))
            {
                //TODO: create specific exception
                throw new Exception();
            }

            var result = JsonConvert.DeserializeObject<T>(stringResult);

            return result;
        }
    }
}
