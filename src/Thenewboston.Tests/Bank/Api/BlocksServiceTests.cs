using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Moq;
using Newtonsoft.Json;
using Thenewboston.Bank.Api;
using Thenewboston.Bank.Models;
using Thenewboston.Common.Api.Models;
using Thenewboston.Common.Http;
using Thenewboston.Common.Models;
using Xunit;
using Block = Thenewboston.Common.Models.Block;
using BlockMessage = Thenewboston.Common.Models.BlockMessage;

namespace Thenewboston.Tests.Bank
{
    public class BlocksServiceTests
    {
        #region Test Models

        private PaginatedResponseModel<BankBlock> CreateMockBlock()
        {
            return new PaginatedResponseModel<BankBlock>() {
                Count = 1,
                Next = string.Empty,
                Previous = string.Empty,
                Results =
                    new List<BankBlock>() {
                        new BankBlock {
                            Id = "c6fc11cf-8948-4d32-96c9-d56caa6d5b24",
                            Created = DateTime.Parse("2020-10-08T02:18:07.324999Z"),
                            Modified = DateTime.Parse("2020-10-08T02:18:07.325044Z"),
                            BalanceKey = "a37e2836805975f334108b55523634c995bd2a4db610062f404510617e83126f",
                            Sender = "a37e2836805975f334108b55523634c995bd2a4db610062f404510617e83126f",
                            Signature =
                                "a2ba346d98cb1f7ce6bf017240d674a9928796ddb564a2c8817e68ead0ea02d960e970fe581c6d3a25b9876e1873d51c882b23d843e32f511d9575ef60d2940d"
                        }
                    }
            };
        }

        private Block CreateMockBlockMessage()
        {
            return new Block() {
                AccountNumber = "0cdd4ba04456ca169baca3d66eace869520c62fe84421329086e03d91a68acdb",
                Message = new BlockMessage() {
                    BalanceKey = "ce51f0d9facaa7d3e69657429dd3f961ce70077a8efb53dcda508c7c0a19d2e3",
                    Transactions = new List<BlockTransaction>() {
                        new BlockTransaction() {
                            Amount = "12.5",
                            Recipient = "484b3176c63d5f37d808404af1a12c4b9649cd6f6769f35bdf5a816133623fbc"
                        },
                        new BlockTransaction() {
                            Amount = "1", Recipient = "5e12967707909e62b2bb2036c209085a784fabbc3deccefee70052b6181c8ed8"
                        },
                        new BlockTransaction() {
                            Amount = "4", Recipient = "ad1f8845c6a1abb6011a2a434a079a087c460657aad54329a84b406dce8bf314"
                        }
                    }
                },
                Signature =
                    "ee5a2f2a2f5261c1b633e08dd61182fd0db5604c853ebd8498f6f28ce8e2ccbbc38093918610ea88a7ad47c7f3192ed955d9d1529e7e390013e43f25a5915c0f"
            };
        }

        #endregion

        #region Mock Service

        private IBlocksService BuildBlockGetMock()
        {
            var response = new HttpResponseMessage(System.Net.HttpStatusCode.OK);
            response.Content = new StringContent(JsonConvert.SerializeObject(CreateMockBlock()), Encoding.UTF8,
                "application/json");
            var requestSenderMock = new Mock<IHttpRequestSender>();

            requestSenderMock
                .Setup(s => s.GetAsync(It.IsAny<string>()))
                .ReturnsAsync(response);

            IBlocksService service = new BlocksService(requestSenderMock.Object);
            return service;
        }

        private IBlocksService BuildBlockPostMock()
        {
            var requestSenderMock = new Mock<IHttpRequestSender>();
            requestSenderMock.Setup(s => s.PostAsync(It.IsAny<string>(), It.IsAny<HttpContent>()))
                .ReturnsAsync(new HttpResponseMessage(System.Net.HttpStatusCode.Created));

            IBlocksService service = new BlocksService(requestSenderMock.Object);
            return service;
        }

        #endregion

        #region Tests

        [Fact]
        public async void BlockReturnedAsync()
        {
            var service = BuildBlockGetMock();
            var returnedBlock = await service.GetBlocksAsync();
            var expectedResult = JsonConvert.SerializeObject(CreateMockBlock());
            var actualResult = JsonConvert.SerializeObject(returnedBlock);
            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        public async void BlockPostedAsync()
        {
            var service = BuildBlockPostMock();
            var response = await service.PostBlocksAsync(CreateMockBlockMessage());
            Assert.True(response.StatusCode == System.Net.HttpStatusCode.Created);
        }

        #endregion
    }
}