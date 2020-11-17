using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Moq;
using Newtonsoft.Json;
using Thenewboston.Common.Http;
using Thenewboston.Validator.Api;
using Thenewboston.Validator.Models;
using Xunit;

namespace Thenewboston.Tests.Validator.Api
{
    public class ValidatorApiClientServiceTests
    {
        public class GetAccountsAsync
        {
            [Fact]
            public async void ListOfAccountsIsReturned()
            {
                var service = BuildValidatorServiceMock();

                var accounts = await service.GetAccountsAsync();

                Assert.Equal(2, accounts.Count());
                Assert.Equal("9eca00a5-d925-454c-a8d6-ecbb26ec2f76", accounts.ElementAt(0).Id);
            }
        }

        public class GetAccountBalanceAsync
        {
            [Fact]
            public async void AccountBalanceIsReturned()
            {
                var service = BuildValidatorServiceMock();

                var balance = await service.GetAccountBalanceAsync("9eca00a5-d925-454c-a8d6-ecbb26ec2f76");

                Assert.Equal("4294967051.0000000000000000", balance.Balance);
            }
        }

        public class GetAccountBalanceLockAsync
        {
            [Fact]
            public async void AccountBalanceLockIsReturned()
            {
                var service = BuildValidatorServiceMock();

                var balanceLock = await service.GetAccountBalanceLockAsync("9eca00a5-d925-454c-a8d6-ecbb26ec2f76");

                Assert.Equal("21cfd80a31930e801e97d34e3f00a7d9b5c01b2fb531a5ac14cd59d10ab446c8", balanceLock.BalanceLock);
            }
        }

        public static ValidatorApiClientService BuildValidatorServiceMock()
        {
            var requestSender = new Mock<IHttpRequestSender>();

            var listResult = new List<ValidatorAccount>
            {
                new ValidatorAccount
                {
                    Id = "9eca00a5-d925-454c-a8d6-ecbb26ec2f76",
                    AccountNumber = "4d2ec91f37bc553bc538e91195669b666e26b2ea3e4e31507e38102a758d4f86",
                    Balance = "4294967051.0000000000000000",
                    BalanceLock = "21cfd80a31930e801e97d34e3f00a7d9b5c01b2fb531a5ac14cd59d10ab446c8"
                },
                 new ValidatorAccount
                {
                    Id = "ae4d43b0-5c34-4e56-8266-0e3531268815",
                    AccountNumber = "a29baa6ba36f6db707f8f8dacfa82d5e8a28fa616e8cc96cf6d7790f551d79f2",
                    Balance = "175.0000000000000000",
                    BalanceLock = "484b3176c63d5f37d808404af1a12c4b9649cd6f6769f35bdf5a816133623fbc"
                }
            };

            var getAllResponse = new HttpResponseMessage(System.Net.HttpStatusCode.OK);
            getAllResponse.Content = new StringContent(JsonConvert.SerializeObject(listResult), Encoding.UTF8, "application/json");

            var getBalanceResponse = new HttpResponseMessage(System.Net.HttpStatusCode.OK);
            getBalanceResponse.Content = new StringContent(JsonConvert.SerializeObject(
                new ValidatorAccountBalance
                {
                    Balance = listResult[0].Balance
                }),
                Encoding.UTF8,
                "application/json");

            var getBalanceLockResponse = new HttpResponseMessage(System.Net.HttpStatusCode.OK);
            getBalanceLockResponse.Content = new StringContent(JsonConvert.SerializeObject(
                new ValidatorAccountBalanceLock
                {
                    BalanceLock = listResult[0].BalanceLock
                }),
                Encoding.UTF8,
                "application/json");


            requestSender
                .Setup(x => x.GetAsync(It.Is<string>(s => !s.Contains("balance"))))
                .Returns(Task.FromResult(getAllResponse));
            requestSender
                .Setup(x => x.GetAsync(It.Is<string>(s => s.Contains("balance") && !s.Contains("lock"))))
                .Returns(Task.FromResult(getBalanceResponse));
            requestSender
                .Setup(x => x.GetAsync(It.Is<string>(s => s.Contains("balance_lock"))))
                .Returns(Task.FromResult(getBalanceLockResponse));



            var validatorService = new ValidatorApiClientService(requestSender.Object);
            return validatorService;
        }
    }
}
