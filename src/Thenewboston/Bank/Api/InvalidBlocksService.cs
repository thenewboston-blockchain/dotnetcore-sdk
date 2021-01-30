using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Thenewboston.Bank.Api.Models;
using Thenewboston.Bank.Models;
using Thenewboston.Common.Api.Models;
using Thenewboston.Common.Http;

namespace Thenewboston.Bank.Api
{
    internal class InvalidBlocksService : IInvalidBlocksService
    {
        private readonly IHttpRequestSender _requestSender;

        public InvalidBlocksService(IHttpRequestSender requestSender)
        {
            _requestSender = requestSender;
        }

        public async Task<PaginatedResponseModel<BankInvalidBlock>> GetInvalidBankBlocksAsync(int offset = 0, int limit = 10)
        {
            var response = await _requestSender.GetAsync($"/invalid_blocks?offset={offset}&limit={limit}");

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception();
            }

            var responseContent = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<PaginatedResponseModel<BankInvalidBlock>>(responseContent);
        }

    }
}