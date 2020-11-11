using System;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Thenewboston.Common.Http;
using Thenewboston.Validator.Models;

namespace Thenewboston.Validator.Api
{
    public class ValidatorConfigService : IValidatorConfigService
    {
        private readonly IHttpRequestSender _requestSender;

        public ValidatorConfigService(IHttpRequestSender requestSender)
        {
            _requestSender = requestSender;
        }

        public async Task<ValidatorConfig> GetValidatorConfigAsync()
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

            var result = JsonConvert.DeserializeObject<ValidatorConfig>(stringResult);

            return result;
        }
    }
}
