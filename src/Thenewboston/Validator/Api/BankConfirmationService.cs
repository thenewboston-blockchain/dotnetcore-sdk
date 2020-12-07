using System;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Thenewboston.Common.Api.Models;
using Thenewboston.Common.Http;

namespace Thenewboston.Validator.Api
{
    public class BankConfirmationService : IBankConfirmationService
    {
        private readonly IHttpRequestSender _requestSender;

        public BankConfirmationService(IHttpRequestSender requestSender)
        {
            _requestSender = requestSender;
        }
        
        public async Task<PaginatedResponseModel> GetBankConfirmationServicesAsync()
        {
            var response = await _requestSender.GetAsync("/bank_confirmation_services");

            if (!response.IsSuccessStatusCode)
            {
                // TODO: Create specific exception
                throw new Exception(); 
            }
            
            var stringResponse = await response.Content.ReadAsStringAsync(); 

            if(string.IsNullOrEmpty(stringResponse))
            {
                // TODO: Create specific exception
                throw new Exception(); 
            }

            var result = JsonConvert.DeserializeObject<PaginatedResponseModel>(stringResponse);

            return result;
        }
    }
}