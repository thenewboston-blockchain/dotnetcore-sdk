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
    public class ConnectionRequestService : IConnectionRequestService
    {
        IHttpRequestSender _requestSender;

        public ConnectionRequestService(IHttpRequestSender requestSender)
        {
            _requestSender = requestSender;
        }

        public async Task<HttpResponseMessage> PostConnectionRequestAsync(ConnectionRequest connectionNotice)
        {
            if( connectionNotice is null ) 
            {
                // TODO: Create specific exception
                throw new Exception();
            }

            var httpContent = new StringContent(JsonConvert.SerializeObject(connectionNotice));
            var jsonString = await httpContent.ReadAsStringAsync();

            if (string.IsNullOrEmpty(jsonString))
            {
                // TODO: Create specific exception
                throw new Exception();
            }

            var result = await _requestSender.PostAsync("/connection_requests", httpContent);
            return result;
        }
    }
}
