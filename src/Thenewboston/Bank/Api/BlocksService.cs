using System;
using System.ComponentModel;
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
    internal class BlocksService : IBlocksService
    {
        private IHttpRequestSender _requestSender;

        public BlocksService(IHttpRequestSender requestSender)
        {
            _requestSender = requestSender;
        }

        public async Task<PaginatedResponseModel<BankBlock>> GetBlocksAsync(int offset = 0, int limit = 10)
        {
            var response = await _requestSender.GetAsync($"/blocks?offset={offset}&limit={limit}");

            if (!response.IsSuccessStatusCode)
            {
                //TODO: create specific exception
                throw new Exception();
            }

            var stringResult = await response.Content.ReadAsStringAsync();

            if (string.IsNullOrEmpty(stringResult))
            {
                //TODO: create specific exception
                throw new Exception();
            }

            var result = JsonConvert.DeserializeObject<PaginatedResponseModel<BankBlock>>(stringResult);

            return result;
        }

        public async Task<BankBlock> PostBlocksAsync(Thenewboston.Common.Models.Block block)
        {
            var httpContent = new StringContent(JsonConvert.SerializeObject(block), Encoding.UTF8, "application/json"); 
            var request = await _requestSender.PostAsync("/blocks", httpContent); 

            if(!request.IsSuccessStatusCode)
            {
                // TODO: Create specific exception
                throw new Exception(); 
            }

            var response = await request.Content.ReadAsStringAsync();
            var responseContent = JsonConvert.DeserializeObject<BankBlock>(response);

            return responseContent;
        }
    }
}