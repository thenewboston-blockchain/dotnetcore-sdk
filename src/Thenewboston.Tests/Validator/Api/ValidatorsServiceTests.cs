using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Moq;
using Newtonsoft.Json;
using Thenewboston.Common.Api.Models;
using Thenewboston.Common.Http;
using Thenewboston.Common.Models;
using Thenewboston.Validator.Api;
using Thenewboston.Validator.Api.Models;
using Thenewboston.Validator.Models;
using Xunit;

namespace Thenewboston.Tests.Validator.Api
{
    public class ValidatorsServiceTests
    {

        public class GetAllValidatorsAsync
        {
            [Fact]
            public async void ListOfValidatorsIsReturned()
            {
                var expectedResponseModel = new PaginatedResponseModel<ValidatorResponseModel>
                {
                    Count = 2,
                    Next = null,
                    Previous = null,
                    Results =
                    new List<ValidatorResponseModel>()
                    {
                        new ValidatorResponseModel
                        {
                            AccountNumber = "ad1f8845c6a1abb6011a2a434a079a087c460657aad54329a84b406dce8bf314",
                            IpAddress = "192.168.1.74",
                            NodeIdentifier = "3afdf37573f1a511def0bd85553404b7091a76bcd79cdcebba1310527b167521",
                            Port = 8000,
                            Protocol = "http",
                            Version = "v1.0",
                            DefaultTransactionFee = 4,
                            RootAccountFile = "https://gist.githubusercontent.com/buckyroberts/519b5cb82a0a5b5d4ae8a2175b722520/raw/9237deb449e27cab93cb89ea3346ecdfc61fe9ea/0.json",
                            RootAccountFileHash = "4694e1ee1dcfd8ee5f989e59ae40a9f751812bf5ca52aca2766b322c4060672b",
                            SeedBlockIdentifier = "",
                            DailyConfirmationRate = "0",
                            Trust = "100.00"
                        },
                        new ValidatorResponseModel
                        {
                            AccountNumber = "4d2ec91f37bc553bc538e91195669b666e26b2ea3e4e31507e38102a758d4f86",
                            IpAddress = "86.168.1.23",
                            NodeIdentifier = "59479a31c3b91d96bb7a0b3e07f18d4bf301f1bb0bde05f8d36d9611dcbe7cbf",
                            Port = 80,
                            Protocol = "http",
                            Version = "v1.0",
                            DefaultTransactionFee = 2,
                            RootAccountFile = "https://gist.githubusercontent.com/buckyroberts/519b5cb82a0a5b5d4ae8a2175b722520/raw/9237deb449e27cab93cb89ea3346ecdfc61fe9ea/0.json",
                            RootAccountFileHash = "4694e1ee1dcfd8ee5f989e59ae40a9f751812bf5ca52aca2766b322c4060672b",
                            SeedBlockIdentifier = "",
                            DailyConfirmationRate = "1",
                            Trust = "91.56"
                        }
                    }
                };

                var service = BuildBankValidatorMock(expectedResponseModel);

                var validators = await service.GetAllValidatorsAsync(0, 10);

                var expectedResponseModelStr = JsonConvert.SerializeObject(expectedResponseModel);
                var actualResponseModelStr = JsonConvert.SerializeObject(validators);

                Assert.Equal(expectedResponseModelStr, actualResponseModelStr);
            }
        }

        internal static IValidatorsService BuildBankValidatorMock(PaginatedResponseModel<ValidatorResponseModel> expectedResponseModel)
        {
            var requestSender = new Mock<IHttpRequestSender>();

            var getAllResponse = new HttpResponseMessage(System.Net.HttpStatusCode.OK);
            getAllResponse.Content = new StringContent(JsonConvert.SerializeObject(expectedResponseModel), Encoding.UTF8, "application/json");

            requestSender
                .Setup(x => x.GetAsync(It.IsAny<string>()))
                .Returns(Task.FromResult(getAllResponse));

            var validatorService = new ValidatorsService(requestSender.Object);
            return validatorService;
        }
    }
}
