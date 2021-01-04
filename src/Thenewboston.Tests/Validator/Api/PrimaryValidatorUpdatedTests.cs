using System.Net.Http;
using System.Threading.Tasks;
using Moq;
using Thenewboston.Common.Http;
using Thenewboston.Validator.Api;
using Thenewboston.Validator.Models;
using Xunit;

namespace Thenewboston.Tests.Validator.Api
{
    public class PrimaryValidatorUpdatedTests
    {
        // ********************************************
        // Primary Validator Updated Tests            *
        // Created 11/28/2020 based on available      *
        // documentation                              *
        // ********************************************


        #region Primary Validator Updated Mock Models 

        private PrimaryValidatorUpdatedModel CreateMockPrimaryValidatorUpdatedModel()
        {
            return new PrimaryValidatorUpdatedModel()
            {
                Message = new PrimaryValidatorUpdatedMessage()
                {
                    IPAddress = "192.168.1.20",
                    Port = "8000",
                    Protocol = "http"
                },
                NodeIdentifier = "d5356888dc9303e44ce52b1e06c3165a7759b9df1e6a6dfbd33ee1c3df1ab4d1",
                Signature = "ccb4c9f0669abfcd1cea330fa4e45d87689fb08d2fd26b4cf05c87b2fdb1dae543024888243a84d02fd9bb8320c41f4de45d6212747e49a02a365fd42883fd01"
            }; 
        }

        #endregion

        #region Primary Validator Updated Mock Services 

        public IPrimaryValidatorUpdatedService BuildMockPrimaryValidatorUpdatesServiceApproveUpgrade()
        {
            var httpRequest = new Mock<IHttpRequestSender>();
            var returnContent = new HttpResponseMessage(System.Net.HttpStatusCode.OK);
            var service = new PrimaryValidatorUpdatedService(httpRequest.Object);

            httpRequest.Setup(s => s.PostAsync(It.IsAny<string>(), It.IsAny<HttpContent>()))
                .ReturnsAsync(returnContent); 

            return service; 
        }

        public IPrimaryValidatorUpdatedService BuildMockPrimaryValidatorUpdatesServiceRejectUpgrade()
        {
            var httpRequest = new Mock<IHttpRequestSender>();
            var returnContent = new HttpResponseMessage(System.Net.HttpStatusCode.BadRequest);
            var service = new PrimaryValidatorUpdatedService(httpRequest.Object);

            httpRequest.Setup(s => s.PostAsync(It.IsAny<string>(), It.IsAny<HttpContent>()))
                .ReturnsAsync(returnContent);

            return service;
        }

        #endregion

        #region Tests

        [Fact]
        public async Task PrimaryValidatorUpdatedReceivingNodeApprovesTest()
        {
            var service = BuildMockPrimaryValidatorUpdatesServiceApproveUpgrade();
            var expectedResult = new HttpResponseMessage(System.Net.HttpStatusCode.OK);
            var result = await service.PostPrimaryValidatorUpdatedAsync(CreateMockPrimaryValidatorUpdatedModel());
            Assert.Equal(expectedResult.StatusCode, result.StatusCode); 
        }

        [Fact]
        public async Task PrimaryValidatorUpdatedReceivingNodeRejectsTest()
        {
            var service = BuildMockPrimaryValidatorUpdatesServiceRejectUpgrade();
            var expectedResult = new HttpResponseMessage(System.Net.HttpStatusCode.BadRequest);
            var result = await service.PostPrimaryValidatorUpdatedAsync(CreateMockPrimaryValidatorUpdatedModel());
            Assert.Equal(expectedResult.StatusCode, result.StatusCode);
        }

        #endregion 
    }
}
