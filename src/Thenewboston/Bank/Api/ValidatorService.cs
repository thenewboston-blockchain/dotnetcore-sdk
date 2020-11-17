using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Thenewboston.Common.Http;
using Thenewboston.Common.Models;

namespace Thenewboston.Bank.Api
{
    public class ValidatorService : IValidatorService
    {
        private readonly IHttpRequestSender _requestSender;

        public ValidatorService(IHttpRequestSender requestSender)
        {
            _requestSender = requestSender;
        }

        public async Task<IEnumerable<ValidatorNode>> GetAllValidatorsAsync()
        {
            var response = await _requestSender.GetAsync("/validators");

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

            var result = JsonConvert.DeserializeObject<IEnumerable<ValidatorNode>>(stringResult);

            return result;
        }
    }
}
