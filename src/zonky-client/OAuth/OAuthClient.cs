using System.Collections.Generic;
using System.Threading.Tasks;

namespace Rpliva.Zonky.Client.OAuth
{
    public class OAuthClient : IOAuthClient
    {
        private readonly IApiClient Client;

        public OAuthClient(IApiClient client)
        {
            Client = client;
        }

        public async Task<Token> GetAccessToken(string username, string password)
        {
            var parameters = new Dictionary<string, string>
            {
                {"username", username},
                {"password", password},
                {"grant_type", "password"},
                {"scope", "SCOPE_APP_WEB"}
            };
            return await Client.FormPostAsync<Token>(parameters, "oauth/token");
        }
    }
}
