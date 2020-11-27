using System.Net.Http;
using System.Threading.Tasks;
using Moq;
using Thenewboston.Common.Http;
using Thenewboston.Validator.Api;
using Thenewboston.Validator.Models;
using Xunit;

namespace Thenewboston.Tests.Bank.Api
{
    public class UpgradeRequestTests
    {
        #region Upgrade Request Mock Models

        public UpgradeRequest CreateMockUpgradeRequest()
        {
            return new UpgradeRequest()
            {
                Message = new UpgradeRequestMessage()
                {
                    ValidatorNodeIdentifier = "59479a31c3b91d96bb7a0b3e07f18d4bf301f1bb0bde05f8d36d9611dcbe7cbf"
                },
                NodeIdentifier = "d5356888dc9303e44ce52b1e06c3165a7759b9df1e6a6dfbd33ee1c3df1ab4d1",
                Signature = "90a365d1950b1765b973d3d21d763f9bea7eb1f9d1f33d6e9c3f8eb4803022f97ad3173474707b4786e556cccf4ca0a0e81d18edb655b090967c96c22c40140a"
            }; 
        }

        #endregion

        #region Upgrade Request Mock Services

        public IUpgradeRequestService BuildUpgradeRequestServiceNodeAcceptsMock()
        {
            var requestSender = new Mock<IHttpRequestSender>();
            var httpResponse = new HttpResponseMessage(System.Net.HttpStatusCode.OK);

            requestSender.Setup(s => s.PostAsync(It.IsAny<string>(), It.IsAny<HttpContent>()))
                .ReturnsAsync(httpResponse); 

            var service = new UpgradeRequestService(requestSender.Object);
            return service; 
        }

        public IUpgradeRequestService BuildUpgradeRequestServiceNodeRejectsMock()
        {
            var requestSender = new Mock<IHttpRequestSender>();
            var httpResponse = new HttpResponseMessage(System.Net.HttpStatusCode.BadRequest);

            requestSender.Setup(s => s.PostAsync(It.IsAny<string>(), It.IsAny<HttpContent>()))
                .ReturnsAsync(httpResponse);

            var service = new UpgradeRequestService(requestSender.Object);
            return service;
        }

        #endregion

        #region Tests

        [Fact]
        public async Task UpgradeRequestNodeAcceptsTest()
        {
            var service = BuildUpgradeRequestServiceNodeAcceptsMock();
            var result = await service.PostUpgradeRequestAsync(CreateMockUpgradeRequest());
            var expectedResult = new HttpResponseMessage(System.Net.HttpStatusCode.OK);
            Assert.Equal(expectedResult.StatusCode, result.StatusCode); 
        }

        [Fact]
        public async Task UpgradeRequestNodeRejectsTest()
        {
            var service = BuildUpgradeRequestServiceNodeRejectsMock();
            var result = await service.PostUpgradeRequestAsync(CreateMockUpgradeRequest());
            var expectedResult = new HttpResponseMessage(System.Net.HttpStatusCode.BadRequest);
            Assert.Equal(expectedResult.StatusCode, result.StatusCode);
        }

        #endregion 
    }
}
