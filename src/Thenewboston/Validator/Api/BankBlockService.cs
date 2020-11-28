using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Thenewboston.Common.Http;
using Thenewboston.Validator.Models;


namespace Thenewboston.Validator.Api
{
    public class BankBlockService : IBankBlockService
    {
        private readonly IHttpRequestSender _requestSender;

        public BankBlockService(IHttpRequestSender requestSender)
        {
            _requestSender = requestSender;
        }
        
        public async Task<HttpResponseMessage> PostBankBlockAsync(ValidatorBankBlock block)
        {
            var httpContent = new StringContent(JsonConvert.SerializeObject(block), Encoding.UTF8, "application/json"); 
            var request = await _requestSender.PostAsync("/bank_blocks", httpContent); 

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