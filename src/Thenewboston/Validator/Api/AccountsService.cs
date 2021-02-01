using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Thenewboston.Common.Api.Models;
using Thenewboston.Common.Http;
using Thenewboston.Common.Math;
using Thenewboston.Validator.Models;

namespace Thenewboston.Validator.Api
{
    internal class AccountsService : IAccountsService
    {
        private readonly IHttpRequestSender _requestSender;

        public AccountsService(IHttpRequestSender requestSender)
        {
            _requestSender = requestSender;
        }

        public async Task<PaginatedResponseModel<ValidatorAccount>> GetAccountsAsync(int offset = 0, int limit = 10)
        {
            var response = await _requestSender.GetAsync($"/accounts?offset={offset}&limit={limit}");

            if (!response.IsSuccessStatusCode)
            {
                //TODO: create specific exception
                throw new Exception();
            }

            var stringResult = await response.Content.ReadAsStringAsync();

            if (string.IsNullOrEmpty(stringResult))
            {
                //TODO: Create specific exception
                throw new Exception(); 
            }

            var settings = new JsonSerializerSettings();
            settings.FloatParseHandling = FloatParseHandling.Decimal;
            settings.Converters.Add(new JsonBigDecimalConverter());

            var result = JsonConvert.DeserializeObject<PaginatedResponseModel<ValidatorAccount>>(stringResult, settings);

            return result;
        }

        public async Task<ValidatorAccountBalance> GetAccountBalanceAsync(string accountNumber)
        {
            var response = await _requestSender.GetAsync($"/accounts/{accountNumber}/balance");

            if(!response.IsSuccessStatusCode)
            {
                //TODO: create specific exception
                throw new Exception();
            }

            var stringResult = await response.Content.ReadAsStringAsync();

            if(string.IsNullOrEmpty(stringResult))
            {
                //TODO: create specific exception
                throw new Exception();
            }

            var settings = new JsonSerializerSettings();
            settings.FloatParseHandling = FloatParseHandling.Decimal;
            settings.Converters.Add(new JsonBigDecimalConverter());

            var result = JsonConvert.DeserializeObject<ValidatorAccountBalance>(stringResult, settings);

            return result;
        }

        public async Task<ValidatorAccountBalanceLock> GetAccountBalanceLockAsync(string accountNumber)
        {
            var response = await _requestSender.GetAsync($"/accounts/{accountNumber}/balance_lock");

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

            var result = JsonConvert.DeserializeObject<ValidatorAccountBalanceLock>(stringResult);

            return result;
        }
    }
}
