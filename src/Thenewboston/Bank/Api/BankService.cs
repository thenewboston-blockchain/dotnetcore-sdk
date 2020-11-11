using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Thenewboston.Bank.Api.Models;
using Thenewboston.Bank.Models;
using Thenewboston.Common.Http;

namespace Thenewboston.Bank.Api
{
    public class BankService : IBankApiClient
    {
        private IHttpRequestSender _requestSender;

        public BankService(IHttpRequestSender requestSender)
        {
            _requestSender = requestSender;
        }

        public async Task<IEnumerable<BankAccount>> GetAccountsAsync()
        {
            var response = await _requestSender.GetAsync("/accounts");
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

            var result = JsonConvert.DeserializeObject<IEnumerable<BankAccount>>(stringResult);

            return result;
        }

        public async Task<BankAccount> UpdateAccountAsync(string accountNumber, AccountRequestModel account)
        {
            var jsonAccount = JsonConvert.SerializeObject(account);
            var httpContent = new StringContent(jsonAccount, Encoding.UTF8, "application/json");

            var response = await _requestSender.PatchAsync($"/accounts/{accountNumber}", httpContent);
            var stringResult = string.Empty; 

            if (response.IsSuccessStatusCode)
            {
                stringResult = await response.Content.ReadAsStringAsync()?? string.Empty;
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

            var result = JsonConvert.DeserializeObject<BankAccount>(stringResult);

            return result;
        }
    }
}
