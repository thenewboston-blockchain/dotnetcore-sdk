using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Thenewboston.Bank.Api;
using Thenewboston.Bank.Api.Models;
using Thenewboston.Bank.Models;

namespace Thenewboston.Tests.Mocks.Bank
{
    public class MockBankService : IBankApiClient
    {
        public async Task<IEnumerable<BankAccount>> GetAccountsAsync()
        {
            return new List<BankAccount>
            {
                new BankAccount
                {
                    Id = "9eca00a5-d925-454c-a8d6-ecbb26ec2f76",
                    AccountNumber = "4d2ec91f37bc553bc538e91195669b666e26b2ea3e4e31507e38102a758d4f86",
                    Created = DateTime.Now.AddDays(-3),
                    Modified = DateTime.Now,
                    Trust = "99.73"
                },
                 new BankAccount
                {
                    Id = "ae4d43b0-5c34-4e56-8266-0e3531268815",
                    AccountNumber = "a29baa6ba36f6db707f8f8dacfa82d5e8a28fa616e8cc96cf6d7790f551d79f2",
                    Created = DateTime.Now.AddDays(-3),
                    Modified = DateTime.Now,
                    Trust = "94.61"
                }
            };
        }

        public async Task<BankAccount> UpdateAccountAsync(AccountRequestModel account)
        {
            return new BankAccount
            {
                Id = "64426fc5-b3ac-42fb-b75b-d5ccfcdc6872",
                AccountNumber = "0cdd4ba04456ca169baca3d66eace869520c62fe84421329086e03d91a68acdb",
                Created = DateTime.Now.AddDays(-3),
                Modified = DateTime.Now,
                Trust = account.Message.Trust.ToString()
            };
        }
    }
}
