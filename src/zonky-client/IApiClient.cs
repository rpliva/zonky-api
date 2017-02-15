using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Rpliva.Zonky.Client.OAuth;

namespace Rpliva.Zonky.Client
{
    public interface IApiClient
    {
        Task<T> FormPostAsync<T>(Dictionary<string, string> parameters, string url);
        Task<T> GetAsync<T>(string url, Token auth = null, Dictionary<string, string> otherHeaders = null);
        Task<HttpResponseMessage> JsonPostAsync(string jsonMessage, string url, Token auth = null, Dictionary<string, string> otherHeaders = null);
    }
}