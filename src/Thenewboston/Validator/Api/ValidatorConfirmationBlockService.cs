using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Thenewboston.Common.Http;
using Thenewboston.Common.Math;
using Thenewboston.Common.Models;

namespace Thenewboston.Validator.Api
{
    public class ValidatorConfirmationBlockService : IValidatorConfirmationBlockService
    {
        private readonly IHttpRequestSender _requestSender;

        public ValidatorConfirmationBlockService(IHttpRequestSender requestSender)
        {
            _requestSender = requestSender;
        }

        /// <summary>
        /// Posts a new <see cref="CommonConfirmationBlockMessage"/> containing information pertaining to a validator's block confirmation
        /// and returns a <see cref="ConfirmationBlockResponse"/>
        /// </summary>
        /// <param name="confirmationBlockMessage">Message containing the validator's confirmation block info</param>
        /// <returns></returns>
        public async Task<ConfirmationBlockResponse> PostConfirmationBlockAsync(ConfirmationBlock confirmationBlockMessage)
        {
            var jsonConfirmationBlockMessage = JsonConvert.SerializeObject(confirmationBlockMessage);
            var httpContent = new StringContent(jsonConfirmationBlockMessage, Encoding.UTF8, "application/json");

            var response = await _requestSender.PostAsync("/confirmation_block", httpContent); 

            if(!response.IsSuccessStatusCode)
            {
                // TODO: Add specific exceptions
                throw new Exception(); 
            }

            var stringResult = await response.Content.ReadAsStringAsync(); 

            if(string.IsNullOrEmpty(stringResult))
            {
                // TODO: Add specific exceptions
                throw new Exception(); 
            }

            var settings = new JsonSerializerSettings();
            settings.FloatParseHandling = FloatParseHandling.Decimal;
            settings.Converters.Add(new JsonBigDecimalConverter());

            var result = JsonConvert.DeserializeObject<ConfirmationBlockResponse>(stringResult, settings);

            return result; 
        }

        /// <summary>
        /// Returns a <see cref="CommonConfirmationBlockMessage"/> containing information about a specific queued confirmation request.
        /// Items returned are still pending validation by the validator
        /// </summary>
        /// <param name="blockIdentifier">The identifier for the requested block</param>
        /// <param name="_requestSender"></param>
        /// <returns></returns>
        public async Task<ConfirmationBlock> GetQueuedConfirmationBlockAsync(string blockIdentifier)
        {
            var response = await _requestSender.GetAsync($"/confirmation_block/{blockIdentifier}/queued");

            if(!response.IsSuccessStatusCode)
            {
                // TODO: Add specific exceptions
                throw new Exception(); 
            }

            var stringResult = await response.Content.ReadAsStringAsync(); 
            
            if(string.IsNullOrEmpty(stringResult))
            {
                // TODO: Add specific exceptions
                throw new Exception(); 
            }

            var settings = new JsonSerializerSettings();
            settings.FloatParseHandling = FloatParseHandling.Decimal;
            settings.Converters.Add(new JsonBigDecimalConverter());

            var result = JsonConvert.DeserializeObject<ConfirmationBlock>(stringResult, settings);

            return result; 
        }

        /// <summary>
        /// Returns a <see cref="CommonConfirmationBlockMessage"/> containing information about a specific valid confirmation request.
        /// Items returned have been validated by the validator
        /// </summary>
        /// <param name="blockIdentifier">The identifier for the requested block</param>
        /// <param name="_requestSender"></param>
        /// <returns></returns>
        public async Task<ConfirmationBlock> GetValidConfirmationBlockAsync(string blockIdentifier)
        {
            var response = await _requestSender.GetAsync($"/confirmation_block/{blockIdentifier}/queued");

            if (!response.IsSuccessStatusCode)
            {
                // TODO: Add specific exceptions
                throw new Exception();
            }

            var stringResult = await response.Content.ReadAsStringAsync();

            if (string.IsNullOrEmpty(stringResult))
            {
                // TODO: Add specific exceptions
                throw new Exception();
            }

            var settings = new JsonSerializerSettings();
            settings.FloatParseHandling = FloatParseHandling.Decimal;
            settings.Converters.Add(new JsonBigDecimalConverter());

            var result = JsonConvert.DeserializeObject<ConfirmationBlock>(stringResult, settings);

            return result;
        }
    }
}
