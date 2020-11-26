using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Thenewboston.Common.Api.Models;
using Thenewboston.Common.Http;
using Thenewboston.Common.Models;

namespace Thenewboston.Bank.Api
{
    public class BlocksService : IBlocksService
    {
        private IHttpRequestSender _requestSender;

        public BlocksService(IHttpRequestSender requestSender)
        {
            _requestSender = requestSender;
        }

        public async Task<PaginatedResponseModel> GetBlocksAsync()
        {
            var response = await _requestSender.GetAsync("/blocks");

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

            var result = JsonConvert.DeserializeObject<PaginatedResponseModel>(stringResult);

            return result;
        }

        public async Task<HttpResponseMessage> PostBlocksAsync(Block block)
        {
            var httpContent = new StringContent(JsonConvert.SerializeObject(block), Encoding.UTF8, "application/json"); 
            var request = await _requestSender.PostAsync("/blocks", httpContent); 

            if(!request.IsSuccessStatusCode)
            {
                // TODO: Create specific exception
                throw new Exception(); 
            }

            var response = new HttpResponseMessage(System.Net.HttpStatusCode.Created);
            return response; 
        }
    }
}