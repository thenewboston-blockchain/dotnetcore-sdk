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
            var stringResult = string.Empty; 

            if (response.IsSuccessStatusCode)
            {
                stringResult = await response.Content.ReadAsStringAsync();
                if(string.IsNullOrEmpty(stringResult))
                {
                    //TODO: Create specific exception
                    throw new Exception(); 
                }
            }
            else
            {
                //TODO: create specific exception
                throw new Exception();
            }

            var result = JsonConvert.DeserializeObject<IEnumerable<ValidatorAccount>>(stringResult);

            return result;
        }

        public async Task<ValidatorAccountBalance> GetAccountBalanceAsync(string accountNumber)
        {
            var response = await _requestSender.GetAsync($"/accounts/{accountNumber}/balance");
            var stringResult = string.Empty; 

            if (response.IsSuccessStatusCode)
            {
                stringResult = await response.Content.ReadAsStringAsync();
                if (string.IsNullOrEmpty(stringResult))
                {
                    //TODO: create specific exception
                    throw new Exception(); 
                }
            }
            else
            {
                //TODO: create specific exception
                throw new Exception();
            }

            var result = JsonConvert.DeserializeObject<ValidatorAccountBalance>(stringResult);

            return result;
        }

        public async Task<ValidatorAccountBalanceLock> GetAccountBalanceLockAsync(string accountNumber)
        {
            var response = await _requestSender.GetAsync($"/accounts/{accountNumber}/balance_lock");
            var stringResult = string.Empty; 

            if (response.IsSuccessStatusCode)
            {
                stringResult = await response.Content.ReadAsStringAsync();
                if (string.IsNullOrEmpty(stringResult))
                {
                    //TODO: create specific exception
                    throw new Exception();
                }
            }
            else
            {
                //TODO: create specific exception
                throw new Exception();
            }

            var result = JsonConvert.DeserializeObject<ValidatorAccountBalanceLock>(stringResult);

            return result;
        }

    }
}
