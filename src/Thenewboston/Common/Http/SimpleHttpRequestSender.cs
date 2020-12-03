using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Thenewboston.Common.Http
{
    public sealed class SimpleHttpRequestSender : IHttpRequestSender
    {
        private Uri _baseAddress; 

        public SimpleHttpRequestSender(string baseAddress)
        {
            CreateBaseAddressURI(baseAddress); 
        }

        private void CreateBaseAddressURI(string baseAddress)
        {
            Uri uriBaseAddress;
            Uri.TryCreate(baseAddress, UriKind.Absolute, out uriBaseAddress);

            if(uriBaseAddress is null)
            {
                throw new Exception("CMN001: The base address provided to the SimpleHttpRequestSender was invalid"); 
            }

            _baseAddress = uriBaseAddress; 
        }

        public async Task<HttpResponseMessage> GetAsync(string uri)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = _baseAddress; 
                var response = await client.GetAsync(uri);
                return response;
            }
        }

        public async Task<HttpResponseMessage> PostAsync(string uri, HttpContent content)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = _baseAddress;
                var response = await client.PostAsync(uri, content);
                return response;
            }
        }

        public async Task<HttpResponseMessage> PatchAsync(string uri, HttpContent content)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = _baseAddress;
                var response = await client.PatchAsync(uri, content);
                return response;
            }
        }

        public async Task<HttpResponseMessage> PutAsync(string uri, HttpContent content)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = _baseAddress;
                var response = await client.PutAsync(uri, content);
                return response;
            }
        }

        public async Task<HttpResponseMessage> DeleteAsync(string uri)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = _baseAddress;
                var response = await client.DeleteAsync(uri);
                return response;
            }
        }
    }
}
