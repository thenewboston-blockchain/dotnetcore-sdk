using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Thenewboston.Accounts.BankApi.Models;

namespace Thenewboston.Accounts.BankApi
{
    public class BankApiClient
    {
        private HttpClient _client;
        private bool _mock;

        public BankApiClient(bool mock = false)
        {
            _mock = mock;
            _client = new HttpClient();
            //TODO: set the client's base address
        }

        public async Task<IEnumerable<AccountResponseModel>> GetAccounts()
        {
            var response = await _client.GetAsync("/accounts");
            var stringResult = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                //TODO: create specific exception
                throw new Exception();
            }

            var result = JsonConvert.DeserializeObject<IEnumerable<AccountResponseModel>>(stringResult);

            return result;
        }
    }
}
