using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Moq;
using Newtonsoft.Json;
using Thenewboston.Common.Api.Models;
using Thenewboston.Common.Http;
using Thenewboston.Validator.Api;
using Thenewboston.Validator.Api.Models;
using Xunit;

namespace Thenewboston.Tests.Validator.Api
{
    public class BankConfirmationServiceTests
    {
        #region Test Models

        private PaginatedResponseModel<BankConfirmationServiceResponse> CreateMockResponse()
        {
            return new PaginatedResponseModel<BankConfirmationServiceResponse>() {
                Count = 1,
                Next = string.Empty,
                Previous = string.Empty,
                Results =
                    new List<BankConfirmationServiceResponse>() {
                        new BankConfirmationServiceResponse() {
                            Id = "09e96a28-4d71-4123-85a3-882a9bdad114",
                            Created = DateTime.Parse("2020-09-11T02:15:13.638227Z"),
                            Modified = DateTime.Parse("2020-09-11T02:15:13.638326Z"),
                            End = DateTime.Parse("2020-09-23T00:06:55.320993Z"),
                            Start = DateTime.Parse("2020-09-20T00:06:55.320993Z"),
                            Bank = "b58b4b8a-d8f9-4395-a0de-f9df150bb093"
                        }
                    }
            };
        }

        #endregion

        #region Mock Service

        private IBankConfirmationService BuildBankConfirmationServiceGetMock()
        {
            var response = new HttpResponseMessage(System.Net.HttpStatusCode.OK);
            response.Content = new StringContent(JsonConvert.SerializeObject(CreateMockResponse()), Encoding.UTF8,
                "application/json");
            var requestSenderMock = new Mock<IHttpRequestSender>();

            requestSenderMock
                .Setup(s => s.GetAsync(It.IsAny<string>()))
                .ReturnsAsync(response);

            IBankConfirmationService service = new BankConfirmationService(requestSenderMock.Object);
            return service;
        }

        #endregion

        #region Tests

        [Fact]
        public async void ConfirmationServiceReturnedAsync()
        {
            var service = BuildBankConfirmationServiceGetMock();
            var returnedBlock = await service.GetBankConfirmationServicesAsync(0, 10);
            var expectedResult = JsonConvert.SerializeObject(CreateMockResponse());
            var actualResult = JsonConvert.SerializeObject(returnedBlock);
            Assert.Equal(expectedResult, actualResult);
        }

        #endregion
    }
}