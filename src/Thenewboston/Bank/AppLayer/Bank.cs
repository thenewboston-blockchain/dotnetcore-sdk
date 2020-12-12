using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Thenewboston.Bank.Api;
using Thenewboston.Bank.Models;
using Thenewboston.Common.Http;

namespace Thenewboston.Bank.AppLayer
{
    public class Bank
    {
        private readonly AccountsService _accountsService;

        public Bank(string ip, int port)
        {
            var requestSender = new SimpleHttpRequestSender($"{ip}:{port}");
            _accountsService = new AccountsService(requestSender);
        }

        public async Task<IEnumerable<BankAccount>> GetAccounts()
        {
            var result = await _accountsService.GetAccountsAsync();
            return result;
        }

    }
}
