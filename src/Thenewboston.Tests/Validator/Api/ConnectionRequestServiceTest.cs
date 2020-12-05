using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Moq;
using Thenewboston.Common.Http;
using Thenewboston.Validator.Api;
using Thenewboston.Validator.Models;
using Xunit;

namespace Thenewboston.Tests.Validator.Api
{
    public class ConnectionRequestServiceTest
    {
        public ConnectionRequest CreateMockConnectionRequest()
        {
            return new ConnectionRequest()
            {
                Message = new ConnectionRequestMessage()
                {
                    IpAddress = "192.168.1.232",
                    Port = "8000",
                    Protocol = "http"
                },
                NodeIdentifier = "d5356888dc9303e44ce52b1e06c3165a7759b9df1e6a6dfbd33ee1c3df1ab4d1",
                Signature = "3c88665e123e7e25a8b9d9592f3269ab4efc4bcba989a103a898e2625933261b1cccdaf2f52eca9c58d2bf033968ab6b702089bca8fc6e0c80b3b002a5e05b03"
            };
        }

        public IConnectionRequestService ConnectionRequestAcceptsMock()
        {
            var requestSender = new Mock<IHttpRequestSender>();
            var httpResponse = new HttpResponseMessage(System.Net.HttpStatusCode.OK);

            requestSender.Setup(s => s.PostAsync(It.IsAny<string>(), It.IsAny<HttpContent>()))
                .ReturnsAsync(httpResponse);

            var service = new ConnectionRequestService(requestSender.Object);
            return service;
        }

        public IConnectionRequestService ConnectionRequestRejectsMock()
        {
            var requestSender = new Mock<IHttpRequestSender>();
            var httpResponse = new HttpResponseMessage(System.Net.HttpStatusCode.BadRequest);

            requestSender.Setup(s => s.PostAsync(It.IsAny<string>(), It.IsAny<HttpContent>()))
                .ReturnsAsync(httpResponse);

            var service = new ConnectionRequestService(requestSender.Object);
            return service;
        }

        [Fact]
        public async Task UpgradeRequestNodeAcceptsTest()
        {
            var service = ConnectionRequestAcceptsMock();
            var result = await service.PostConnectionRequestAsync(CreateMockConnectionRequest());
            var expectedResult = new HttpResponseMessage(System.Net.HttpStatusCode.OK);
            Assert.Equal(expectedResult.StatusCode, result.StatusCode);
        }

        [Fact]
        public async Task UpgradeRequestNodeRejectsTest()
        {
            var service = ConnectionRequestRejectsMock();
            var result = await service.PostConnectionRequestAsync(CreateMockConnectionRequest());
            var expectedResult = new HttpResponseMessage(System.Net.HttpStatusCode.BadRequest);
            Assert.Equal(expectedResult.StatusCode, result.StatusCode);
        }
    }
}
