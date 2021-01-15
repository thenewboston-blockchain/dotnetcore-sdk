using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Moq;
using Newtonsoft.Json;
using Thenewboston.Bank.Api;
using Thenewboston.Bank.Api.Models;
using Thenewboston.Bank.Models;
using Thenewboston.Common.Api.Models;
using Thenewboston.Common.Http;
using Thenewboston.Common.Models;
using Xunit;

namespace Thenewboston.Tests.Bank.Api
{
    public class BankConfirmationBlockServiceTests
    {
        // ***************************************
        // Bank Confirmation Block Service Tests *
        // Created 11/22/2020 based on available *
        // documentation and bank API response   *
        // ***************************************

        #region Test Models 

        private PaginatedResponseModel<BankConfirmationBlock> CreateMockBankConfirmationBlock()
        {
            return new PaginatedResponseModel<BankConfirmationBlock>()
            {
                Count = 1,
                Next = string.Empty,
                Previous = string.Empty,
                Results =
                    new List<BankConfirmationBlock>()
                    {
                        new BankConfirmationBlock
                        {
                            Id = "e7c5c2e0-8ed1-4eb3-abd8-97fa2e5ca8db",
                            CreatedDate = DateTime.Parse("2020-10-08T02:18:07.908635Z"),
                            ModifiedDate = DateTime.Parse("2020-10-08T02:18:07.908702Z"),
                            BlockIdentifier = "824614aa97edb391784b17ce6956b70aed31edf741c1858d43ae4d566b2a13ed",
                            Block = "c6fc11cf-8948-4d32-96c9-d56caa6d5b24",
                            Validator = "e2a138b0-ebe9-47d2-a146-fb4d9d9ca378"
                        },
                    }
            };
        }

        #endregion

        #region Mock Service

        private IBankConfirmationBlockService BuildConfirmationBlockGetMock()
        {
            var response = new HttpResponseMessage(System.Net.HttpStatusCode.OK); 
            response.Content = new StringContent(JsonConvert.SerializeObject(CreateMockBankConfirmationBlock()), Encoding.UTF8, "application/json");
            var requestSenderMock = new Mock<IHttpRequestSender>();
            requestSenderMock
                .Setup(s => s.GetAsync(It.IsAny<string>()))
                .ReturnsAsync(response);
            IBankConfirmationBlockService service = new BankConfirmationBlockService(requestSenderMock.Object);

            return service; 
        }

        #endregion

        #region Tests

        [Fact]
        public async void BankConfirmationBlockReturnedAsync()
        {
            var service = BuildConfirmationBlockGetMock();
            var returnedBankConfirmationBlock = await service.GetAllBankConfiramtionBlocksAsync(0, 10);
            var expectedResult = JsonConvert.SerializeObject(CreateMockBankConfirmationBlock());
            var actualResult = JsonConvert.SerializeObject(returnedBankConfirmationBlock);
            Assert.Equal(expectedResult, actualResult); 
        }

        #endregion 
    }
}
