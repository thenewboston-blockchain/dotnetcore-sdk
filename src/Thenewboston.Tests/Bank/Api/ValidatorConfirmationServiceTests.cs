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
    public class ValidatorConfirmationServiceTests
    {
        #region Test Models

        private PaginatedResponseModel<ValidatorConfirmationServiceResponse> CreateMockResponse()
        {
            return new PaginatedResponseModel<ValidatorConfirmationServiceResponse>() {
                Count = 1,
                Next = string.Empty,
                Previous = string.Empty,
                Results =
                    new List<ValidatorConfirmationServiceResponse>() {
                        new ValidatorConfirmationServiceResponse() {
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

        private BankValidatorConfirmationService CreateMockValidatorConfirmationServiceMessage()
        {
            return new BankValidatorConfirmationService() {
                Message = new ValidatorConfirmationServiceMessage() {
                    End = DateTime.Parse("2020-07-09T22:10:25Z"), Start = DateTime.Parse("2020-08-09T22:10:25Z")
                },
                NodeIdentifier = "59479a31c3b91d96bb7a0b3e07f18d4bf301f1bb0bde05f8d36d9611dcbe7cbf",
                Signature =
                    "2a4b90e97566d4c46cb302e8297841ebe0b9f5ce6f30217721dedb4bfdc48944d14f46032e33246b6a60a942bc48fd9541057b7b1c635d4346436deab9f4bf01"
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

            IValidatorConfirmationService service = new ValidatorConfirmationService(requestSenderMock.Object);
            return service;
        }

        private IValidatorConfirmationService BuildValidatorConfirmationServicePostMock()
        {
            var requestSenderMock = new Mock<IHttpRequestSender>();
            requestSenderMock.Setup(s => s.PostAsync(It.IsAny<string>(), It.IsAny<HttpContent>()))
                .ReturnsAsync(new HttpResponseMessage(System.Net.HttpStatusCode.Created));

            IValidatorConfirmationService service = new ValidatorConfirmationService(requestSenderMock.Object);
            return service;
        }

        #endregion

        #region Tests

        [Fact]
        public async void ConfirmationServiceReturnedAsync()
        {
            var service = BuildValidatorConfirmationServiceGetMock();
            var returnedBlock = await service.GetValidatorConfirmationServicesAsync();
            var expectedResult = JsonConvert.SerializeObject(CreateMockResponse());
            var actualResult = JsonConvert.SerializeObject(returnedBlock);
            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        public async void BlockPostedAsync()
        {
            var service = BuildValidatorConfirmationServicePostMock();
            var response =
                await service.PostValidatorConfirmationServiceAsync(CreateMockValidatorConfirmationServiceMessage());
            Assert.True(response.StatusCode == System.Net.HttpStatusCode.Created);
        }

        #endregion
    }
}