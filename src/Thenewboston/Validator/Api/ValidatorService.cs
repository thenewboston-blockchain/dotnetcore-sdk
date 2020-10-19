using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Thenewboston.Common.Http;
using Thenewboston.Validator.Models;

namespace Thenewboston.Validator.Api
{
    public class ValidatorService : IValidatorApiClient
    {
        private readonly IHttpRequestSender _requestSender;

        public ValidatorService(IHttpRequestSender requestSender)
        {
            _requestSender = requestSender;
        }

        public async Task<IEnumerable<ValidatorAccount>> GetAccountsAsync()
        {
            var response = await _requestSender.GetAsync("/accounts");
            var stringResult = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                //TODO: create specific exception
                throw new Exception();
            }

            var result = JsonConvert.DeserializeObject<IEnumerable<ValidatorAccount>>(stringResult);

            return result;
        }

        public async Task<ValidatorAccountBalance> GetAccountBalance(string accountNumber)
        {
            var response = await _requestSender.GetAsync($"/accounts/{accountNumber}/balance");
            var stringResult = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                //TODO: create specific exception
                throw new Exception();
            }

            var result = JsonConvert.DeserializeObject<ValidatorAccountBalance>(stringResult);

            return result;
        }

        public async Task<ValidatorAccountBalanceLock> GetAccountBalanceLock(string accountNumber)
        {
            var response = await _requestSender.GetAsync($"/accounts/{accountNumber}/balance_lock");
            var stringResult = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                //TODO: create specific exception
                throw new Exception();
            }

            var result = JsonConvert.DeserializeObject<ValidatorAccountBalanceLock>(stringResult);

            return result;
        }

    }
}
