using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Thenewboston.Bank.Models;
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
        
        public async Task<IEnumerable<BankInvalidBlock>> GetInvalidBankBlocksAsync()
        {
            try
            {
                var response = await _requestSender.GetAsync("/invalid_blocks");
                if (!response.IsSuccessStatusCode)
                {
                    //TODO Use a More Specific Exception Type
                    throw  new Exception();
                }

                var responseContent = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<IEnumerable<BankInvalidBlock>>(responseContent);
            }
            catch (Exception )
            {
                //TODO Handle Possible Known Exception Types
                throw;
            }
        }

        public async Task<BankInvalidBlock> SendInvalidBlocksToBankAsync(BankInvalidBlockRequest model)
        {
            try
            {
                var content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
                var response = await _requestSender.PostAsync("/invalid_blocks", content);
                if (!response.IsSuccessStatusCode)
                    throw new Exception("Error Sending Invalid Block to Bank"); //TODO Use Specific Exception 

                var responseContent = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<BankInvalidBlock>(responseContent);
            }
            catch
            {
                //TODO Handle Specific Exceptions Types
                throw;
            }
        }
    }
}