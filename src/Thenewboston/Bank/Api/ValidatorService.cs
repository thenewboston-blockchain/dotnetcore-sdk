using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Thenewboston.Bank.Api.Models;
using Thenewboston.Bank.Models;
using Thenewboston.Common.Api.Models;
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

        public async Task<PaginatedResponseModel> GetAllValidatorsAsync()
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

            var result = JsonConvert.DeserializeObject<PaginatedResponseModel>(stringResult);

            return result;
        }

        public async Task<BankValidator> PatchValidatorAsync(string nodeIdentifier, RequestModel trust)
        {
            var jsonTrust = JsonConvert.SerializeObject(trust);
            var httpContent = new StringContent(jsonTrust, Encoding.UTF8, "application/json");

            var response = await _requestSender.PatchAsync($"/validators/{nodeIdentifier}", httpContent);

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

            var result = JsonConvert.DeserializeObject<BankValidator>(stringResult);

            return result;
        }
    }
}
