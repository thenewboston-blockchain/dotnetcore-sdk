using System;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Thenewboston.Bank.Models;
using Thenewboston.Common.Http;

namespace Thenewboston.Bank.Api.Models
{
    internal class ConfigService : IConfigService
    {
        private readonly IHttpRequestSender _requestSender;

        public ConfigService(IHttpRequestSender requestSender)
        {
            _requestSender = requestSender;
        }

        public async Task<BankConfig> GetBankConfigAsync()
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

            var result = JsonConvert.DeserializeObject<BankConfig>(stringResult);

            return result;
        }
    }
}
