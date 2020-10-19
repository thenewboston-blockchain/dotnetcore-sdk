using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Thenewboston.Bank.Api.Models;
using Thenewboston.Bank.Models;

namespace Thenewboston.Bank.Api
{
    public class BankService : IBankApiClient
    {
        private HttpClient _client;

        public BankService()
        {
            _client = new HttpClient();
            //TODO: set the client's base address
        }

        public async Task<IEnumerable<BankAccount>> GetAccountsAsync()
        {
            var response = await _client.GetAsync("/accounts");
            var stringResult = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                //TODO: create specific exception
                throw new Exception();
            }

            var result = JsonConvert.DeserializeObject<IEnumerable<BankAccount>>(stringResult);

            return result;
        }

        public async Task<BankAccount> UpdateAccountAsync(AccountRequestModel account)
        {
            var jsonAccount = JsonConvert.SerializeObject(account);
            var httpContent = new StringContent(jsonAccount, Encoding.UTF8, "application/json");

            var response = await _client.PatchAsync("/accounts", httpContent);
            var stringResult = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                //TODO: create specific exception
                throw new Exception();
            }

            var result = JsonConvert.DeserializeObject<BankAccount>(stringResult);

            return result;
        }
    }
}
