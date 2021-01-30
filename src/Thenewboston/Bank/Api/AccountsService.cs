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

namespace Thenewboston.Bank.Api
{
    internal class AccountsService : IAccountsService
    {
        private IHttpRequestSender _requestSender;

        public AccountsService(IHttpRequestSender requestSender)
        {
            _requestSender = requestSender;
        }

        public async Task<PaginatedResponseModel<BankAccount>> GetAccountsAsync(int offset = 0, int limit = 10)
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
                //TODO: create specific exception
                throw new Exception();
            }

            var result = JsonConvert.DeserializeObject<PaginatedResponseModel<BankAccount>>(stringResult);

            return result;
        }

        public async Task<BankAccount> UpdateAccountAsync(string accountNumber, RequestModel account)
        {
            var jsonAccount = JsonConvert.SerializeObject(account);
            var httpContent = new StringContent(jsonAccount, Encoding.UTF8, "application/json");

            var response = await _requestSender.PatchAsync($"/accounts/{accountNumber}", httpContent);

            if (!response.IsSuccessStatusCode)
            {
                //TODO: create specific exception 
                throw new Exception();
            }

            var stringResult = await response.Content.ReadAsStringAsync()?? string.Empty;

            if (string.IsNullOrEmpty(stringResult))
            {
                //TODO: create specific exception 
                throw new Exception();
            }

            var result = JsonConvert.DeserializeObject<BankAccount>(stringResult);

            return result;
        }
    }
}
