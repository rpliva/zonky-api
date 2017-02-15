using System.Collections.Generic;
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

        public async Task<HttpResponseMessage> JsonPostAsync(string jsonMessage, string url, Token auth = null, Dictionary<string, string> otherHeaders = null)
        {
            ApplyHeaders(auth, otherHeaders);

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
            ApplyHeaders(null, new Dictionary<string, string> { { "authorization", "Basic d2ViOndlYg==" } });

            using (var content = new FormUrlEncodedContent(parameters))
            {
                using (var response = await Client.PostAsync(BaseUrl + url, content))
                {
                    return JsonConvert.DeserializeObject<T>(await response.Content.ReadAsStringAsync());
                }
            }
        }

        public async Task<T> GetAsync<T>(string url, Token auth = null, Dictionary<string, string> otherHeaders = null)
        {
            ApplyHeaders(auth, otherHeaders);

            using (var response = await Client.GetAsync(BaseUrl + url))
            {
                return JsonConvert.DeserializeObject<T>(await response.Content.ReadAsStringAsync());
            }
        }

        protected virtual void CleanupHeaders()
        {
            Client.DefaultRequestHeaders.Clear();
        }

        protected virtual void ApplyHeaders(Token auth, Dictionary<string, string> otherHeaders)
        {
            CleanupHeaders();

            if (auth != null)
            {
                Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(auth.TokenType, auth.AccessToken);
            }
            if (otherHeaders != null)
            {
                foreach (var otherHeader in otherHeaders)
                {
                    Client.DefaultRequestHeaders.Add(otherHeader.Key, otherHeader.Value);
                }
            }
        }
    }
}
