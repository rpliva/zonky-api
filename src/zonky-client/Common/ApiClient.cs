using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Rpliva.Zonky.Client.OAuth;

namespace Rpliva.Zonky.Client.Common
{
    public class ApiClient : IApiClient
    {
        private readonly HttpClient Client;
        private readonly string BaseUrl;

        public ApiClient(HttpClient client, string baseUrl)
        {
            Client = client;
            BaseUrl = baseUrl;
        }

        public async Task<HttpResponseMessage> JsonPostAsync(string jsonMessage, string url, Token auth = null)
        {
            if (auth != null)
            {
                Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(auth.TokenType, auth.AccessToken);
            }

            using (var content = new StringContent(jsonMessage, Encoding.UTF8, "application/json"))
            {
                using (var response = await Client.PostAsync(BaseUrl + url, content))
                {
                    return response;
                }
            }
        }

        public async Task<T> FormPostAsync<T>(Dictionary<string, string> parameters, string url)
        {
            Client.DefaultRequestHeaders.TryAddWithoutValidation("authorization", "Basic d2ViOndlYg==");

            using (var content = new FormUrlEncodedContent(parameters))
            {
                using (var response = await Client.PostAsync(BaseUrl + url, content))
                {
                    return JsonConvert.DeserializeObject<T>(await response.Content.ReadAsStringAsync());
                }
            }
        }

        public async Task<T> GetAsync<T>(string url, Token auth = null)
        {
            if (auth != null)
            {
                Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(auth.TokenType, auth.AccessToken);
            }

            using (var response = await Client.GetAsync(BaseUrl + url))
            {
                return JsonConvert.DeserializeObject<T>(await response.Content.ReadAsStringAsync());
            }
        }
    }
}
