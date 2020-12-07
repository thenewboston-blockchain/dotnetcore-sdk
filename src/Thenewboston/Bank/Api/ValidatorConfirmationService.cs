using System;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Thenewboston.Common.Api.Models;
using Thenewboston.Common.Http;

namespace Thenewboston.Bank.Api
{
    public class ValidatorConfirmationService : IValidatorConfirmationService
    {
        private readonly IHttpRequestSender _requestSender;

        public ValidatorConfirmationService(IHttpRequestSender requestSender)
        {
            _requestSender = requestSender;
        }
        
        public async Task<PaginatedResponseModel> GetValidatorConfirmationServicesAsync()
        {
            var response = await _requestSender.GetAsync("/validator_confirmation_services"); 
            
            if(!response.IsSuccessStatusCode)
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