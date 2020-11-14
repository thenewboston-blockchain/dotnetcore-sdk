using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Thenewboston.Bank.Models;
using Thenewboston.Common.Http;

namespace Thenewboston.Bank.Api
{
    public class BankTransactionService : IBankTransactions
    {
        private IHttpRequestSender _requestSender;

        public BankTransactionService(IHttpRequestSender requestSender)
        {
            _requestSender = requestSender;
        }

        public async Task<IEnumerable<BankTransaction>> GetAllTransactionsAsync()
        {
            var response = await _requestSender.GetAsync("/bank_transactions");
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

            var result = JsonConvert.DeserializeObject<IEnumerable<BankTransaction>>(stringResult);

            return result;
        }
    }
}