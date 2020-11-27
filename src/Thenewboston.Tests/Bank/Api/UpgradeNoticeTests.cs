using System.Net.Http;
using System.Threading.Tasks;
using Moq;
using Newtonsoft.Json;
using Thenewboston.Bank.Api;
using Thenewboston.Bank.Models;
using Thenewboston.Common.Http;
using Xunit;

namespace Thenewboston.Tests.Bank.Api
{
    public class UpgradeNoticeTests
    {
        // ***************************************
        // Bank Upgrade Notice Tests             *
        // Created 11/27/2020 based on available *
        // documentation                         *
        // ***************************************

        #region Mock Test Models

        private UpgradeNotice CreateUpgradeNoticeModelMock()
        {
            return new UpgradeNotice()
            {
                Message = new UpgradeNoticeMessage()
                {
                    BankNodeIdentifier = "d5356888dc9303e44ce52b1e06c3165a7759b9df1e6a6dfbd33ee1c3df1ab4d1"
                },
                NodeIdentifier = "59479a31c3b91d96bb7a0b3e07f18d4bf301f1bb0bde05f8d36d9611dcbe7cbf",
                Signature = "e9862cf176523449417b5f3426cb7bf0a3813ef04fae3330faa50b6468d9da9c55967a24c40040eaa6bc33843804bda9a0307bffe906ed8c7b2a55c15dabaa0d"
            }; 
        }

        #endregion

        #region Mock Services

        public IUpgradeNoticeService BuildUpgradeNoticeServiceServerAcceptsMock()
        {
            var requestSender = new Mock<IHttpRequestSender>();
            var serializedContent = new StringContent(JsonConvert.SerializeObject(CreateUpgradeNoticeModelMock()));
            var response = new HttpResponseMessage(System.Net.HttpStatusCode.OK);

            requestSender.Setup(s => s.PostAsync(It.IsAny<string>(), It.IsAny<HttpContent>()))
                .ReturnsAsync(response);

            return new UpgradeNoticeService(requestSender.Object); 
        }

        public IUpgradeNoticeService BuildUpgradeNoticeServiceServerRejectsMock()
        {
            var requestSender = new Mock<IHttpRequestSender>();
            var serializedContent = new StringContent(JsonConvert.SerializeObject(CreateUpgradeNoticeModelMock()));
            var response = new HttpResponseMessage(System.Net.HttpStatusCode.BadRequest);

            requestSender.Setup(s => s.PostAsync(It.IsAny<string>(), It.IsAny<HttpContent>()))
                .ReturnsAsync(response);

            return new UpgradeNoticeService(requestSender.Object);
        }

        #endregion

        #region Tests

        [Fact]
        public async Task UpgradeNoticeBankAcceptsTest()
        {
            var service = BuildUpgradeNoticeServiceServerAcceptsMock();
            var result = await service.PostUpgradeNoticeAsync(CreateUpgradeNoticeModelMock());
            var expectedResult = new HttpResponseMessage(System.Net.HttpStatusCode.OK);
            Assert.Equal(expectedResult.StatusCode, result.StatusCode);
        }

        [Fact]
        public async Task UpgradeNoticeBankRejectsTest()
        {
            var service = BuildUpgradeNoticeServiceServerRejectsMock();
            var result = await service.PostUpgradeNoticeAsync(CreateUpgradeNoticeModelMock());
            var expectedResult = new HttpResponseMessage(System.Net.HttpStatusCode.BadRequest);
            Assert.Equal(expectedResult.StatusCode, result.StatusCode);
        }

        #endregion 
    }
}
