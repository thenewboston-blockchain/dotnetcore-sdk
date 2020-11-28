using System;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Thenewboston.Common.Api.Models;
using Thenewboston.Common.Http;
using Thenewboston.Validator.Models;

namespace Thenewboston.Validator.Api
{
    public class ConnectedBanksService : IConnectedBanksService
    {
        private readonly IHttpRequestSender _requestSender;

        public ConnectedBanksService(IHttpRequestSender requestSender)
        {
            _requestSender = requestSender;
        }

        public async Task<PaginatedResponseModel<ValidatorBank>> GetBanksAsync()
        {
            var response = await _requestSender.GetAsync("/banks");

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

            var result = JsonConvert.DeserializeObject<PaginatedResponseModel<ValidatorBank>>(stringResult);

            return result;
        }
    }
}
