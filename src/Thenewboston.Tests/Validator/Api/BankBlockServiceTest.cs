using System.Collections.Generic;
using System.Net.Http;
using Moq;
using Thenewboston.Common.Http;
using Thenewboston.Common.Models;
using Thenewboston.Validator.Api;
using Thenewboston.Validator.Models;
using Xunit;

namespace Thenewboston.Tests.Validator.Api
{
    public class BankBlockServiceTest
    {
        #region Test Models
        private ValidatorBankBlock CreateMockBankBlock()
        {
            return new ValidatorBankBlock()
            {
                BankBlock = new Block()
                {
                    AccountNumber = "0cdd4ba04456ca169baca3d66eace869520c62fe84421329086e03d91a68acdb",
                    Message = new BlockMessage()
                    {
                        BalanceKey = "ee7a6d21feb2905605f9af446566e003decec3de2f55a6eff9815d41fcde59e0",
                        Transactions = new List<BlockTransaction>()
                        {
                            new BlockTransaction() {
                                Amount = 4.125,
                                Recipient = "484b3176c63d5f37d808404af1a12c4b9649cd6f6769f35bdf5a816133623fbc"
                            },
                            new BlockTransaction() {
                                Amount = 1,
                                Recipient = "5e12967707909e62b2bb2036c209085a784fabbc3deccefee70052b6181c8ed8"
                            },
                            new BlockTransaction() {
                                Amount = 4,
                                Recipient = "ad1f8845c6a1abb6011a2a434a079a087c460657aad54329a84b406dce8bf314"
                            }
                        }
                    },
                    Signature = "e8b5215193cd5f91029b2a7a9ff2426b0a9fc0032f5a0f74ec0e6cc2f3ac9f20acd170f90e1557e561c85d34daa37d0cec90901f3d4c9579700847f67de22a05"
                },
                NodeIdentifier = "d5356888dc9303e44ce52b1e06c3165a7759b9df1e6a6dfbd33ee1c3df1ab4d1",
                Signature = "4f019d36d362f09960399fe51dd67d7ddbee27d73994558cf4015bb13260957f861afaa1694d40fd0397ed2a889834d8a20bff4c3417bbde383e2cd4e219cb0f"
            };
        }
        
        #endregion
        
        #region Mock Service

        private IBankBlockService BuildBankBlockPostMock()
        {
            var requestSenderMock = new Mock<IHttpRequestSender>();

            requestSenderMock.Setup(s => s.PostAsync(It.IsAny<string>(), It.IsAny<HttpContent>()))
                .ReturnsAsync(new HttpResponseMessage(System.Net.HttpStatusCode.Created)); 

            IBankBlockService service = new BankBlockService(requestSenderMock.Object);
            return service;
        }
        
        #endregion
        
        #region Tests
        
        [Fact]
        public async void BankConfirmationBlockMessagePostedAsync()
        {
            var service = BuildBankBlockPostMock();
            var response = await service.PostBankBlockAsync(CreateMockBankBlock());
            Assert.True(response.StatusCode == System.Net.HttpStatusCode.Created);
        }
        
        #endregion
    }
}