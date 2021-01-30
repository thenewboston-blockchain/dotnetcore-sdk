using System;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Thenewboston.Common.Api.Models;
using Thenewboston.Common.Http;
using Thenewboston.Validator.Api.Models;

namespace Thenewboston.Validator.Api
{
    internal class BankConfirmationService : IBankConfirmationService
    {
        private readonly IHttpRequestSender _requestSender;

        public BankConfirmationService(IHttpRequestSender requestSender)
        {
            _requestSender = requestSender;
        }

        public async Task<PaginatedResponseModel<BankConfirmationServiceResponse>> GetBankConfirmationServicesAsync(
            int offset = 0,
            int limit = 10)
        {
            var response = await _requestSender.GetAsync($"/bank_confirmation_services?offset={offset}&limit={limit}");

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
                JsonConvert.DeserializeObject<PaginatedResponseModel<BankConfirmationServiceResponse>>(stringResponse);

            return result;
        }
    }
}