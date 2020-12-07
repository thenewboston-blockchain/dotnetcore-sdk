using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Thenewboston.Validator.Models;

namespace Thenewboston.Validator.Api
{
    public interface IConnectionRequestService
    {
        Task<HttpResponseMessage> PostConnectionRequestAsync(ConnectionRequest connectionNotice);
    }
}
