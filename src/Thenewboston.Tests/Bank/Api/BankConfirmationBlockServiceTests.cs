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

        private PaginatedResponseModel<BankConfirmationBlockResponse> CreateMockBankConfirmationBlock()
        {
            return new PaginatedResponseModel<BankConfirmationBlockResponse>()
            {
                Count = 1,
                Next = string.Empty,
                Previous = string.Empty,
                Results =
                    new List<BankConfirmationBlockResponse>()
                    {
                        new BankConfirmationBlockResponse
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

        private ConfirmationBlock CreateMockConfirmationBlockMessage()
        {
            return new ConfirmationBlock()
            {
                Message = new ConfirmationBlockMessage()
                {
                    Block = new ConfirmationBankBlock()
                    {
                        AccountNumber = "0cdd4ba04456ca169baca3d66eace869520c62fe84421329086e03d91a68acdb",
                        Message = new ConfirmationBankBlockMessage()
                        {
                            BalanceKey = "e6a41b658e17ab2db4355176c8160de6a66b07e5cbdd85244b55b38b4fd26e92",
                            Transactions = new List<ConfirmationBankBlockTransaction>()
                            {
                                new ConfirmationBankBlockTransaction()
                                {
                                    Amount = "4",
                                    Recipient = "484b3176c63d5f37d808404af1a12c4b9649cd6f6769f35bdf5a816133623fbc"
                                },
                                new ConfirmationBankBlockTransaction()
                                {
                                    Amount = "1",
                                    Recipient = "5e12967707909e62b2bb2036c209085a784fabbc3deccefee70052b6181c8ed8"
                                },
                                new ConfirmationBankBlockTransaction()
                                {
                                    Amount = "4",
                                    Recipient = "ad1f8845c6a1abb6011a2a434a079a087c460657aad54329a84b406dce8bf314"
                                }
                            }
                        }
                    },
                    Signature = "d857184b7d3121a8f9dccab09062fafc82dd0fb30a5d53e19ab25a587171bb9c6b33858353cd3ff7ddc1ad2bfc59a885e85827799bcfc082fd048f9bf34bd404"
                },
                UpdatedBalances = new List<ConfirmationUpdatedBalanceRecord>()
                {
                    new ConfirmationUpdatedBalanceRecord()
                    {
                        AccountNumber = "0cdd4ba04456ca169baca3d66eace869520c62fe84421329086e03d91a68acdb",
                        Balance = "4294967014",
                        BalanceLock = "729ce6ce619aeedf260221c7687c51d8a6845fbb5407b11c8cd26eaa7c8a6125"
                    },
                    new ConfirmationUpdatedBalanceRecord()
                    {
                        AccountNumber = "484b3176c63d5f37d808404af1a12c4b9649cd6f6769f35bdf5a816133623fbc",
                        Balance = "191",
                    },
                    new ConfirmationUpdatedBalanceRecord()
                    {
                        AccountNumber = "5e12967707909e62b2bb2036c209085a784fabbc3deccefee70052b6181c8ed8",
                        Balance = "18",
                    },
                    new ConfirmationUpdatedBalanceRecord()
                    {
                        AccountNumber = "ad1f8845c6a1abb6011a2a434a079a087c460657aad54329a84b406dce8bf314",
                        Balance = "72",
                    }
                },
                BlockIdentifier = "4c9595b2b661a23e665256d6826ae940bd4ea82bef0c1ba7b3104e40a4c42b91",
                NodeIdentifier = "3afdf37573f1a511def0bd85553404b7091a76bcd79cdcebba1310527b167521",
                Signature = "b4d335fa7662216acba06c18d93c6cfb688c8057cbe9193ddc8e6fb3702ba1d979e43b09e06c6c7c38358bbee5243dc37a52c5212298c2259be48285e3da130c"
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

        private IBankConfirmationBlockService BuildConfirmationBlockPostMock()
        {
            var requestSenderMock = new Mock<IHttpRequestSender>();

            requestSenderMock.Setup(s => s.PostAsync(It.IsAny<string>(), It.IsAny<HttpContent>()))
                .ReturnsAsync(new HttpResponseMessage(System.Net.HttpStatusCode.Created)); 

            IBankConfirmationBlockService service = new BankConfirmationBlockService(requestSenderMock.Object);
            return service;
        }

        #endregion

        #region Tests

        [Fact]
        public async void BankConfirmationBlockReturnedAsync()
        {
            var service = BuildConfirmationBlockGetMock();
            var returnedBankConfirmationBlock = await service.GetAllBankConfiramtionBlocksAsync();
            var expectedResult = JsonConvert.SerializeObject(CreateMockBankConfirmationBlock());
            var actualResult = JsonConvert.SerializeObject(returnedBankConfirmationBlock);
            Assert.Equal(expectedResult, actualResult); 
        }

        [Fact]
        public async void BankConfirmationBlockMessagePostedAsync()
        {
            var service = BuildConfirmationBlockPostMock();
            var response = await service.PostConfirmationBlockAsync(CreateMockConfirmationBlockMessage());
            Assert.True(response.StatusCode == System.Net.HttpStatusCode.Created);
        }

        #endregion 
    }
}
