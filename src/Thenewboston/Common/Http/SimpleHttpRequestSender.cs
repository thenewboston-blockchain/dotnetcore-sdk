using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Thenewboston.Common.Http
{
    public class SimpleHttpRequestSender : IHttpRequestSender
    {
        private HttpClient _client;

        public SimpleHttpRequestSender(string baseAddress)
        {
            _client = new HttpClient();
            _client.BaseAddress = new Uri(baseAddress);
        }

        public Task<HttpResponseMessage> GetAsync(string uri)
        {
            var response = _client.GetAsync(uri);

            return response;
        }

        public Task<HttpResponseMessage> PostAsync(string uri, HttpContent content)
        {
            var response = _client.PostAsync(uri, content);

            return response;
        }

        public Task<HttpResponseMessage> PatchAsync(string uri, HttpContent content)
        {
            var response = _client.PatchAsync(uri, content);

            return response;
        }

        public Task<HttpResponseMessage> PutAsync(string uri, HttpContent content)
        {
            var response = _client.PutAsync(uri, content);

            return response;
        }

        public Task<HttpResponseMessage> DeleteAsync(string uri)
        {
            var response = _client.DeleteAsync(uri);

            return response;
        }
    }
}
