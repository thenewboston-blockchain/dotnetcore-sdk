using System.Net;
using System.Net.Http;
using System.Text;
using Moq;
using Newtonsoft.Json;
using Thenewboston.Bank.Api;
using Thenewboston.Bank.Api.Models;
using Thenewboston.Bank.Models;
using Thenewboston.Common.Http;
using Thenewboston.Common.Models;
using Xunit;

namespace Thenewboston.Tests.Bank.Api
{
    public class BankConfigServiceTests
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

            var service = BuildBankConfigServiceMock(expectedConfig);

            var bankConfig = await service.GetBankConfigAsync();

            var expectedConfigStr = JsonConvert.SerializeObject(expectedConfig);
            var actualConfigStr = JsonConvert.SerializeObject(bankConfig);
            Assert.Equal(expectedConfigStr, actualConfigStr);
        }

        public static IConfigService BuildBankConfigServiceMock(BankConfig expectedConfig)
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
