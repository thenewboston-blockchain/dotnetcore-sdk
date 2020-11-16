using System.Net;
using System.Net.Http;
using System.Text;
using Moq;
using Newtonsoft.Json;
using Thenewboston.Common.Http;
using Thenewboston.Common.Models;
using Thenewboston.Validator.Api;
using Thenewboston.Validator.Models;
using Xunit;

namespace Thenewboston.Tests.Validator.Api
{
    public class ValidatorConfigServiceTests
    {
        [Fact]
        public async void PrimaryValidatorConfigIsReturned()
        {
            var expectedConfig = new ValidatorConfig
            {
                PrimaryValidator = null,
                AccountNumber = "2e86f48216567302527b69eae6c6a188097ed3a9741f43cc3723e570cf47644c",
                IpAddress = "54.183.17.224",
                NodeIdentifier = "2262026a562b0274163158e92e8fbc4d28e519bc5ba8c1cf403703292be84a51",
                Port = null,
                Protocol = "http",
                Version = "v1.0",
                DefaultTransactionFee = 1,
                RootAccountFile = "http://54.183.17.224/media/root_account_file.json",
                RootAccountFileHash = "cc9390cc579dc8a99a1f34c1bea5d54a0f45b27ecee7e38662f0cd853f76744d",
                SeedBlockIdentifier = "",
                DailyConfirmationRate = null,
                NodeType = NodeType.PrimaryValidator
            };

            var service = BuildValidatorConfigServiceMock(expectedConfig);

            var primaryValidatorConfig = await service.GetValidatorConfigAsync();

            var expectedConfigStr = JsonConvert.SerializeObject(expectedConfig);
            var actualConfigStr = JsonConvert.SerializeObject(primaryValidatorConfig);
            Assert.Equal(expectedConfigStr, actualConfigStr);
        }

        [Fact]
        public async void ConfirmationValidatorConfigIsReturned()
        {
            var expectedConfig = new ValidatorConfig
            {
                PrimaryValidator = new ValidatorNode
                {
                    AccountNumber = "2e86f48216567302527b69eae6c6a188097ed3a9741f43cc3723e570cf47644c",
                    IpAddress = "54.183.17.224",
                    NodeIdentifier = "2262026a562b0274163158e92e8fbc4d28e519bc5ba8c1cf403703292be84a51",
                    Port = null,
                    Protocol = "http",
                    Version = "v1.0",
                    DefaultTransactionFee = 1,
                    RootAccountFile = "http://54.183.17.224/media/root_account_file.json",
                    RootAccountFileHash = "cc9390cc579dc8a99a1f34c1bea5d54a0f45b27ecee7e38662f0cd853f76744d",
                    SeedBlockIdentifier = "",
                    DailyConfirmationRate = null,
                    Trust = "100.00"
                },
                AccountNumber = "d5c4db217c032ef21df84be4201766b73e623940ce6d95aedf153da2f8c38626",
                IpAddress = "54.67.72.197",
                NodeIdentifier = "61dbf00c2dd7886f01fda60aca6fffd9799f4612110fe804220570add6b28923",
                Port = null,
                Protocol = "http",
                Version = "v1.0",
                DefaultTransactionFee = 1,
                RootAccountFile = "http://54.67.72.197/media/root_account_file.json",
                RootAccountFileHash = "cc9390cc579dc8a99a1f34c1bea5d54a0f45b27ecee7e38662f0cd853f76744d",
                SeedBlockIdentifier = "",
                DailyConfirmationRate = null,
                NodeType = NodeType.ConfirmationValidator
            };

            var service = BuildValidatorConfigServiceMock(expectedConfig);

            var confirmationValidatorConfig = await service.GetValidatorConfigAsync();

            var expectedConfigStr = JsonConvert.SerializeObject(expectedConfig);
            var actualConfigStr = JsonConvert.SerializeObject(confirmationValidatorConfig);
            Assert.Equal(expectedConfigStr, actualConfigStr);
        }

        public static IConfigService BuildValidatorConfigServiceMock(ValidatorConfig expectedConfig)
        {
            var response = new HttpResponseMessage(HttpStatusCode.OK);
            response.Content = new StringContent(JsonConvert.SerializeObject(expectedConfig), Encoding.UTF8, "application/json");

            var requestSenderMock = new Mock<IHttpRequestSender>();
            IConfigService service = new ConfigService(requestSenderMock.Object);
            requestSenderMock
                .Setup(x => x.GetAsync("/config"))
                .ReturnsAsync(response);

            return service;
        }
    }
}
