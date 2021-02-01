using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Thenewboston.Common.Http
{
    public interface IHttpRequestSender
    {
        Task<HttpResponseMessage> GetAsync(string uri);
        Task<HttpResponseMessage> PostAsync(string uri, HttpContent content);
        Task<HttpResponseMessage> PutAsync(string uri, HttpContent content);
        Task<HttpResponseMessage> PatchAsync(string uri, HttpContent content);
        Task<HttpResponseMessage> DeleteAsync(string uri);
    }
}
