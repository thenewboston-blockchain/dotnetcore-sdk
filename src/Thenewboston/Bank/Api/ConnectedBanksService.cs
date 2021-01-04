using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Thenewboston.Bank.Api.Models;
using Thenewboston.Common.Api.Models;
using Thenewboston.Common.Http;

namespace Thenewboston.Bank.Api
{
    public class ConnectedBanksService : IConnectedBanksService
    {
        private readonly IHttpRequestSender _requestSender;

        public ConnectedBanksService(IHttpRequestSender requestSender)
        {
            _requestSender = requestSender;
        }

        public async Task<PaginatedResponseModel<BankNode>> GetBanksAsync(int offset=0, int limit=10)
        {
            var response = await _requestSender.GetAsync($"/banks?offset={offset}&limit={limit}");

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

            var result = JsonConvert.DeserializeObject<PaginatedResponseModel<BankNode>>(stringResult);

            return result;
        }

        public async Task<BankNode> UpdateBankAsync(string nodeIdentifier, RequestModel payload)
        {
            var jsonPayload = JsonConvert.SerializeObject(payload);
            var httpContent = new StringContent(jsonPayload, Encoding.UTF8, "application/json");

            var response = await _requestSender.PatchAsync($"/banks/{nodeIdentifier}", httpContent);

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

            var result = JsonConvert.DeserializeObject<BankNode>(stringResult);

            return result;
        }
    }
}
