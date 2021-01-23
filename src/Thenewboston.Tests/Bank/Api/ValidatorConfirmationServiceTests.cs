using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Moq;
using Newtonsoft.Json;
using Thenewboston.Bank.Api;
using Thenewboston.Bank.Api.Models;
using Thenewboston.Common.Api.Models;
using Thenewboston.Common.Http;
using Thenewboston.Common.Models;
using Xunit;

namespace Thenewboston.Tests.Bank.Api
{
    public class ValidatorConfirmationServiceTests
    {
        #region Test Models

        private PaginatedResponseModel<Thenewboston.Bank.Api.Models.ValidatorConfirmation> CreateMockResponse()
        {
            return new PaginatedResponseModel<Thenewboston.Bank.Api.Models.ValidatorConfirmation>() {
                Count = 1,
                Next = string.Empty,
                Previous = string.Empty,
                Results =
                    new List<Thenewboston.Bank.Api.Models.ValidatorConfirmation>() {
                        new Thenewboston.Bank.Api.Models.ValidatorConfirmation() {
                            Id = "be9fbc3b-d4df-43d5-9bea-9882a6dd27f6",
                            Created = DateTime.Parse("2020-10-08T02:18:07.324999Z"),
                            Modified = DateTime.Parse("2020-10-08T02:18:07.325044Z"),
                            End = DateTime.Parse("2020-08-09T22:10:24Z"),
                            Start = DateTime.Parse("2020-07-09T22:10:25Z"),
                            Validator = "51461a75-dd8d-4133-81f4-543a3b054149"
                        }
                    }
            };
        }

        #endregion

        #region Mock Service

        private IValidatorConfirmationService BuildValidatorConfirmationServiceGetMock()
        {
            var response = new HttpResponseMessage(System.Net.HttpStatusCode.OK);
            response.Content = new StringContent(JsonConvert.SerializeObject(CreateMockResponse()), Encoding.UTF8,
                "application/json");
            var requestSenderMock = new Mock<IHttpRequestSender>();

            requestSenderMock
                .Setup(s => s.GetAsync(It.IsAny<string>()))
                .ReturnsAsync(response);

            IValidatorConfirmationService service = new Thenewboston.Bank.Api.ValidatorConfirmationService(requestSenderMock.Object);
            return service;
        }

        #endregion

        #region Tests

        [Fact]
        public async void ConfirmationServiceReturnedAsync()
        {
            var service = BuildValidatorConfirmationServiceGetMock();
            var returnedBlock = await service.GetValidatorConfirmationServicesAsync(0, 10);
            var expectedResult = JsonConvert.SerializeObject(CreateMockResponse());
            var actualResult = JsonConvert.SerializeObject(returnedBlock);
            Assert.Equal(expectedResult, actualResult);
        }

        #endregion
    }
}