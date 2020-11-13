using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Moq;
using Newtonsoft.Json;
using Thenewboston.Bank.Api;
using Thenewboston.Bank.Models;
using Thenewboston.Common.Http;
using Xunit;

namespace Thenewboston.Tests.Bank.Api
{
    
    public class BankTransactionTests
    {
        [Fact]
        
        public async void ListOfTransactionsIsReturned()
        {
            var service = BuildBankTransactionMock();

            var transactions = await service.GetAllTransactionsAsync();
            
            Assert.Equal(2,transactions.Count());
            Assert.Equal("2484fbf3-2054-48a4-a1ce-66333cd15470",transactions.ElementAt(0).Id);

        }

        public static BankTransactionService BuildBankTransactionMock()
        {
            var requestSender = new Mock<IHttpRequestSender>();
            
            var listResult = new List<BankTransaction>
            {
                new BankTransaction
                {
                    Id = "2484fbf3-2054-48a4-a1ce-66333cd15470",
                    Block = new BankBlock
                    {
                        Id = "10cc3cec-eef6-453b-8667-f5cb19e6120d",
                        Created = DateTime.Now.AddDays(-3),
                        Modified = DateTime.Now,
                        BalanceKey = "4abccf4280ef61aad6f176a103933a42ed7dbf90d55e7912f404a704ede06f41",
                        Sender = "4abccf4280ef61aad6f176a103933a42ed7dbf90d55e7912f404a704ede06f41",
                        Signature = "c4a7696abc0f1e760a0c87d2a8db1faec060f99a77bf5f669a69dfdb301150db8fdaa2863a5d4a4e75be626ff56aecdbfea034283b1eb5a8e0196fd35f541b0b"
                    },
                    Amount = 1,
                    Recipient = "2e86f48216567302527b69eae6c6a188097ed3a9741f43cc3723e570cf47644c"
                },
                new BankTransaction
                {
                    Id = "2484fbf3-2054-48a4-a1ce-66333cd15470",
                    Block = new BankBlock
                    {
                        Id = "6b9bc4b1-76a7-4105-951f-b729b4befdef",
                        Created = DateTime.Now.AddDays(-3),
                        Modified = DateTime.Now,
                        BalanceKey = "4abccf4280ef61aad6f176a103933a42ed7dbf90d55e7912f404a704ede06f41",
                        Sender = "4abccf4280ef61aad6f176a103933a42ed7dbf90d55e7912f404a704ede06f41",
                        Signature = "c4a7696abc0f1e760a0c87d2a8db1faec060f99a77bf5f669a69dfdb301150db8fdaa2863a5d4a4e75be626ff56aecdbfea034283b1eb5a8e0196fd35f541b0b"
                    },
                    Amount = 498,
                    Recipient = "802f34851bdfa1572f11fc4e58e44be3c01e92399bc4ba8d81e98b02254a0106"

                }
            };
            
            var getAllResponse = new HttpResponseMessage(System.Net.HttpStatusCode.OK);
            getAllResponse.Content = new StringContent(JsonConvert.SerializeObject(listResult),Encoding.UTF8,"application/json");

            requestSender
                .Setup(x => x.GetAsync(It.IsAny<string>()))
                .Returns(Task.FromResult(getAllResponse));
            
            var bankTransactionService = new BankTransactionService(requestSender.Object);
            return bankTransactionService;

        }
    }
    
}