using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Thenewboston.Bank.Models;
using Thenewboston.Common.Api.Models;
using Thenewboston.Common.Http;

namespace Thenewboston.Bank.Api
{
    public class InvalidBlocksService : IInvalidBlocksService
    {
        private readonly IHttpRequestSender _requestSender;

        public InvalidBlocksService(IHttpRequestSender requestSender)
        {
            _requestSender = requestSender;
        }

        public async Task<PaginatedResponseModel<BankInvalidBlock>> GetInvalidBankBlocksAsync(PaginationParams pagination = null)
        {
            var url = "";

            url = pagination switch {
                ( not null and >0 , _ ,_ ) => $"/invalid_blocks?page={pagination.Page}",
                (<= 0 or null , >= 0 , > 0) => $"/invalid_blocks?offset={pagination.Offset}&limit={pagination.Limit}",
                (<= 0 or null , >= 0 , <=0 or null) => $"/invalid_blocks?offset={pagination.Offset}&limit=20",
                _ => $"/invalid_blocks?page=1"
            };
            var response = await _requestSender.GetAsync(url);
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception();
            }

            var responseContent = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<PaginatedResponseModel<BankInvalidBlock>>(responseContent);
        }

        public async Task<BankInvalidBlock> SendInvalidBlocksToBankAsync(BankInvalidBlockRequest model)
        {
            var content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
            var response = await _requestSender.PostAsync("/invalid_blocks", content);
            if (!response.IsSuccessStatusCode)
                throw new Exception("Error Sending Invalid Block to Bank");

            var responseContent = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<BankInvalidBlock>(responseContent);
        }
    }
}