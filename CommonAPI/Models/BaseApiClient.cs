using CommonAPI.Exceptions;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CommonAPI.Models
{
    public abstract class BaseApiClient
    {
        private readonly string _baseUri;

        public BaseApiClient(string baseUri)
        {
            _baseUri = baseUri;
        }
        protected virtual async Task<T> GetAsync<T>(string query, CancellationToken cancelationToken)
        {
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync($"{_baseUri}/{query}", cancelationToken);
                if (!response.IsSuccessStatusCode)
                    throw new BaseException(await response.Content.ReadAsStringAsync());
                return JsonConvert.DeserializeObject<T>(await response.Content.ReadAsStringAsync());
            }
        }

        protected virtual async Task<T> PostAsync<T>(string method, string body, CancellationToken cancelationToken)
        {
            using (var client = new HttpClient())
            {
                var response = await client.PostAsync($"{_baseUri}/{method}", new StringContent(body, Encoding.UTF8, "application/json"));
                if (!response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.TooManyRequests)
                        throw new BaseException(await response.Content.ReadAsStringAsync());
                    throw new ApplicationException(await response.Content.ReadAsStringAsync());
                }

                return JsonConvert.DeserializeObject<T>(await response.Content.ReadAsStringAsync());
            }
        }
    }
}
