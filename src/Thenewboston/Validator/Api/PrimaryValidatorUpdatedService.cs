using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Thenewboston.Common.Http;
using Thenewboston.Validator.Models;

namespace Thenewboston.Validator.Api
{
    public class PrimaryValidatorUpdatedService : IPrimaryValidatorUpdatedService
    {
        private readonly IHttpRequestSender _requestSender;

        public PrimaryValidatorUpdatedService(IHttpRequestSender requestSender)
        {
            _requestSender = requestSender;
        }

        /// <summary>
        /// Notifies a validator on the network that a bank has upgraded its primary validator. 
        /// </summary>
        /// <param name="validatorUpdatedModel"></param>
        /// <returns>200: Ok - Validator will follow bank and sync to the new primary validator or 400: 
        /// - Bad Request - The validator will not follow the bank and will remain on its current network</returns>
        public async Task<HttpResponseMessage> PostPrimaryValidatorUpdatedAsync(PrimaryValidatorUpdatedModel validatorUpdatedModel)
        {
            if(validatorUpdatedModel is null)
            {
                // TODO: Create specific exception
                throw new Exception(); 
            }

            var httpContent = new StringContent(JsonConvert.SerializeObject(validatorUpdatedModel));
            var stringContent = await httpContent.ReadAsStringAsync(); 

            if(string.IsNullOrEmpty(stringContent))
            {
                // TODO: Create specific exception
                throw new Exception(); 
            }

            var response = await _requestSender.PostAsync("primary_validator_updated", httpContent);
            return response; 
        }
    }
}
