using Moq;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http;
using System.Text;
using Thenewboston.Bank.Models;
using Thenewboston.Common.Api;
using Thenewboston.Common.Http;
using Thenewboston.Common.Models;
using Thenewboston.Validator.Api;
using Thenewboston.Validator.Models;
using Xunit;

namespace Thenewboston.Tests.Common.Api
{
    public class NodeConfigServiceTests
    {
        [Fact]
        public async void BankConfigIsReturned()
        {
            var expectedConfig = new BankConfig
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
                    RootAccountFile = "https://gist.githubusercontent.com/buckyroberts/0688f136b6c1332be472a8baf10f78c5/raw/323fcd29672e392be2b934b82ab9eac8d15e840f/alpha-00.json",
                    RootAccountFileHash = "0f775023bee79884fbd9a90a76c5eacfee38a8ca52735f7ab59dab63a75cbee1",
                    SeedBlockIdentifier = "",
                    DailyConfirmationRate = null,
                    Trust = "100.00"
                },
                AccountNumber = "dfddf07ec15cbf363ecb52eedd7133b70b3ec896b488460bcecaba63e8e36be5",
                IpAddress = "143.110.137.54",
                NodeIdentifier = "6dbaff44058e630cb375955c82b0d3bd7bc7e20cad93e74909a8951f747fb8a4",
                Port = null,
                Protocol = "http",
                Version = "v1.0",
                DefaultTransactionFee = 1,
                NodeType = NodeType.Bank
            };

            var service = BuildNodeConfigServiceMock(expectedConfig);

            var bankConfig = await service.GetConfigAsync<BankConfig>();

            var expectedConfigStr = JsonConvert.SerializeObject(expectedConfig);
            var actualConfigStr = JsonConvert.SerializeObject(bankConfig);
            Assert.Equal(expectedConfigStr, actualConfigStr);
        }

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

            var service = BuildNodeConfigServiceMock(expectedConfig);

            var primaryValidatorConfig = await service.GetConfigAsync<ValidatorConfig>();

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

            var service = BuildNodeConfigServiceMock(expectedConfig);

            var confirmationValidatorConfig = await service.GetConfigAsync<ValidatorConfig>();

            var expectedConfigStr = JsonConvert.SerializeObject(expectedConfig);
            var actualConfigStr = JsonConvert.SerializeObject(confirmationValidatorConfig);
            Assert.Equal(expectedConfigStr, actualConfigStr);
        }

        public static INodeConfigService BuildNodeConfigServiceMock<T>(T expectedConfig)
        {
            var response = new HttpResponseMessage(HttpStatusCode.OK);
            response.Content = new StringContent(JsonConvert.SerializeObject(expectedConfig), Encoding.UTF8, "application/json");

            var requestSenderMock = new Mock<IHttpRequestSender>();
            INodeConfigService service = new NodeConfigService(requestSenderMock.Object);
            requestSenderMock
                .Setup(x => x.GetAsync("/config"))
                .ReturnsAsync(response);

            return service;
        }
    }
}
