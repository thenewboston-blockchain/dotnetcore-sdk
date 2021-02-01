using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Thenewboston.Bank.Models;
using Thenewboston.Common.Api.Models;
using Thenewboston.Common.Http;
using Thenewboston.Common.Math;

namespace Thenewboston.Bank.Api
{
    internal class TransactionsService : ITransactionsService
    {
        private IHttpRequestSender _requestSender;

        public TransactionsService(IHttpRequestSender requestSender)
        {
            _requestSender = requestSender;
        }

        public async Task<PaginatedResponseModel<BankTransaction>> GetAllTransactionsAsync(
            int offset = 0,
            int limit = 10)
        {
            var response = await _requestSender.GetAsync($"/bank_transactions?offset={offset}&limit={limit}");
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

            var settings = new JsonSerializerSettings();
            settings.FloatParseHandling = FloatParseHandling.Decimal;
            settings.Converters.Add(new JsonBigDecimalConverter());

            var result = JsonConvert.DeserializeObject<PaginatedResponseModel<BankTransaction>>(stringResult, settings);

            return result;
        }
    }
}