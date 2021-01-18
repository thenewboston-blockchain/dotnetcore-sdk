using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Thenewboston.Bank.Api.Models;
using Thenewboston.Common.Api.Models;
using Thenewboston.Common.Http;
using Thenewboston.Common.Models;
using Thenewboston.Validator.Models;
using Block = Thenewboston.Common.Models.Block;

namespace Thenewboston.Bank.Api
{
    public class ValidatorConfirmationService : IValidatorConfirmationService
    {
        private readonly IHttpRequestSender _requestSender;

        public ValidatorConfirmationService(IHttpRequestSender requestSender)
        {
            _requestSender = requestSender;
        }

        public async Task<PaginatedResponseModel<Models.ValidatorConfirmation>> GetValidatorConfirmationServicesAsync(
            int offset = 0,
            int limit = 10)
        {
            var response = await _requestSender.GetAsync($"/validator_confirmation_services?offset={offset}&limit={limit}");

            if (!response.IsSuccessStatusCode)
            {
                // TODO: Create specific exception
                throw new Exception();
            }

            var stringResponse = await response.Content.ReadAsStringAsync();

            if (string.IsNullOrEmpty(stringResponse))
            {
                // TODO: Create specific exception
                throw new Exception();
            }

            var result =
                JsonConvert.DeserializeObject<PaginatedResponseModel<Models.ValidatorConfirmation>>(
                    stringResponse);

            return result;
        }
    }
}