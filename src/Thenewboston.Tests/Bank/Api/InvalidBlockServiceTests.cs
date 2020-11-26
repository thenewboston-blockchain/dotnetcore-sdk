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
using Thenewboston.Common.Api.Models;
using Thenewboston.Common.Http;
using Xunit;

namespace Thenewboston.Tests.Bank.Api
{
    public class InvalidBlockServiceTests
    {
        public class GetInvalidBankBlocksAsync
        {
            [Fact]
            public async void GetInvalidBlockWithNoPaginationModelReturnedSuccessCodeandData()
            {
                var service = BuildBankInvalidServiceMock();

                var invalidBankBlocks = await service.GetInvalidBankBlocksAsync();

                Assert.Equal(3, invalidBankBlocks.Count);
                Assert.Equal("2bcd53c5-19f9-4226-ab04-3dfb17c3a1fe", invalidBankBlocks.Results.ElementAt(0).Id);
            }
            
            [Fact]
            public async void GetInvalidBlockWithPageOnlyPaginationReturnedSuccessCodeandData()
            {
                var pagination = new PaginationParams() {Page = 1};
                var service = BuildBankInvalidServiceMock();

                var invalidBankBlocks = await service.GetInvalidBankBlocksAsync();

                Assert.Equal(3, invalidBankBlocks.Count);
                Assert.Equal("2bcd53c5-19f9-4226-ab04-3dfb17c3a1fe", invalidBankBlocks.Results.ElementAt(0).Id);
            }
        }
        public class SendInvalidBankBlocksAsync
        {
            [Fact]
            public async void SendInvalidBlockReturnedSuccessCodeandData()
            {
                var service = BuildBankInvalidServiceMock();
                var invalidBankBlocks = await service.SendInvalidBlocksToBankAsync( new BankInvalidBlockRequest());

                Assert.Equal("2bcd53c5-19f9-4226-ab04-3dfb17c3a1fe", invalidBankBlocks.Id);
            }
        }
        
        private static List<BankInvalidBlock> INVALID_BLOCK_TEST_DATA = new List<BankInvalidBlock>
        {
            new BankInvalidBlock
            {
                Id = "2bcd53c5-19f9-4226-ab04-3dfb17c3a1fe",
                BlockIdentifier = "65ae26192dfb9ec41f88c6d582b374a9b42ab58833e1612452d7a8f685dcd4d5",
                Block = "3ff4ebb0-2b3d-429b-ba90-08133fcdee4e",
                PrimaryValidator = "51461a75-dd8d-4133-81f4-543a3b054149",
                ConfirmationValidator= "fcd2dce8-9e4f-4bf1-8dac-cdbaf64e5ce8",
                Created = DateTime.Now.AddDays(-3),
                Modified = DateTime.Now
            },
            new BankInvalidBlock
            {
                Id = "5bcd53c5-19f9-a43b-ab04-3dfb17c3a165",
                BlockIdentifier = "65ae26192dfb9ec41f88c6d582b374a9b42ab58833e1612452d7a8f685dcd4d5",
                Block = "3ff4ebb0-2b3d-429b-ba90-08133fcdee4e",
                PrimaryValidator = "51461a75-dd8d-4133-81f4-543a3b054149",
                ConfirmationValidator= "fcd2dce8-9e4f-4bf1-8dac-cdbaf64e5ce8",
                Created = DateTime.Now.AddDays(-4),
                Modified = DateTime.Now
            },
            new BankInvalidBlock
            {
                Id = "2b9e3180-cf38-4772-9d73-6318ee4113b9",
                BlockIdentifier = "5e12967707909e62b2bb2036c209085a784fabbc3deccefee70052b6181c8ed8",
                Block = "3ff4ebb0-2b3d-429b-ba90-08133fcdee4e",
                PrimaryValidator = "51461a75-dd8d-4133-81f4-543a3b054149",
                ConfirmationValidator= "fcd2dce8-9e4f-4bf1-8dac-cdbaf64e5ce8",
                Created = DateTime.Now.AddDays(-5),
                Modified = DateTime.Now
            }
        };

        private static InvalidBlocksService BuildBankInvalidServiceMock()
        {
            var mockResponse = new PaginatedResponseModel<BankInvalidBlock>() {Results = INVALID_BLOCK_TEST_DATA, Count = INVALID_BLOCK_TEST_DATA.Count};
            var requestSender = new Mock<IHttpRequestSender>();

            var getAllResponse = new HttpResponseMessage(System.Net.HttpStatusCode.OK);
            getAllResponse.Content = new StringContent(JsonConvert.SerializeObject(mockResponse), Encoding.UTF8, "application/json");

            requestSender
                .Setup(x => x.GetAsync(It.IsAny<string>()))
                .Returns(Task.FromResult(getAllResponse));

            var postResponse = new HttpResponseMessage(System.Net.HttpStatusCode.OK);
            postResponse.Content = new StringContent(JsonConvert.SerializeObject(INVALID_BLOCK_TEST_DATA.First()), Encoding.UTF8, "application/json");

            //TODO Setup for more Scenarios
            requestSender
                .Setup(x => x.PostAsync( "/invalid_blocks", It.IsAny<StringContent>()))
                .Returns(Task.FromResult(postResponse));
            requestSender
                .Setup(x => x.GetAsync(It.IsRegex(@"\/invalid_blocks\?offset=[0-9]*&limit=[0-9]*")))
                .Returns(Task.FromResult(getAllResponse)); requestSender
                .Setup(x => x.GetAsync("/invalid_blocks"))
                .Returns(Task.FromResult(getAllResponse));

            var invalidBlockService = new InvalidBlocksService(requestSender.Object);
            return invalidBlockService;
        }  
    }
}