using System;
using Thenewboston.Bank.Api;
using Thenewboston.Common.Http;
using Moq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Thenewboston.Bank.Models;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using Xunit;
using System.Linq;
using Thenewboston.Bank.Api.Models;

namespace Thenewboston.Tests.Bank.Api
{
    public class AccountsServiceTests
    {
        public class GetAccountsAsync
        {
            [Fact]
            public async void ListOfAccountsIsReturned()
            {
                var service = BuildAccountsServiceMock();

                var accounts = await service.GetAccountsAsync();

                Assert.Equal(2, accounts.Count());
                Assert.Equal("9eca00a5-d925-454c-a8d6-ecbb26ec2f76", accounts.ElementAt(0).Id);
            }
        }

        public class UpdateAccountAsync
        {
            [Fact]
            public async void UpdatedAccountIsReturned()
            {
                var service = BuildAccountsServiceMock();

                var account = await service.UpdateAccountAsync(
                    "a29baa6ba36f6db707f8f8dacfa82d5e8a28fa616e8cc96cf6d7790f551d79f2",
                    new RequestModel());

                Assert.Equal("a29baa6ba36f6db707f8f8dacfa82d5e8a28fa616e8cc96cf6d7790f551d79f2", account.AccountNumber);
            }
        }

        public static AccountsService BuildAccountsServiceMock()
        {
            var requestSender = new Mock<IHttpRequestSender>();

            var listResult = new List<BankAccount>
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

            var getAllResponse = new HttpResponseMessage(System.Net.HttpStatusCode.OK);
            getAllResponse.Content = new StringContent(JsonConvert.SerializeObject(listResult), Encoding.UTF8, "application/json");

            requestSender
                .Setup(x => x.GetAsync(It.IsAny<string>()))
                .Returns(Task.FromResult(getAllResponse));

            var updateResult = new BankAccount
            {
                Id = "64426fc5-b3ac-42fb-b75b-d5ccfcdc6872",
                AccountNumber = "a29baa6ba36f6db707f8f8dacfa82d5e8a28fa616e8cc96cf6d7790f551d79f2",
                Created = DateTime.Now.AddDays(-3),
                Modified = DateTime.Now,
                Trust = "94.61"
            };

            var updateResponse = new HttpResponseMessage(System.Net.HttpStatusCode.OK);
            updateResponse.Content = new StringContent(JsonConvert.SerializeObject(updateResult), Encoding.UTF8, "application/json");

            requestSender
                .Setup(x => x.PatchAsync(It.IsAny<string>(), It.IsAny<StringContent>()))
                .Returns(Task.FromResult(updateResponse));

            var bankService = new AccountsService(requestSender.Object);
            return bankService;
        }
    }
}
