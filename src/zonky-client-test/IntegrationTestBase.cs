using System.Net.Http;
using Rpliva.Zonky.Client.Common;
using Rpliva.Zonky.Client.OAuth;

namespace Rpliva.Zonky.Client
{
    public abstract class IntegrationTestBase
    {
        protected readonly HttpClient HttpClient;
        protected readonly ApiClient ApiClient;
        protected readonly Token Token;

        protected IntegrationTestBase()
        {
            HttpClient = new HttpClient();
            ApiClient = new ApiClient(HttpClient, "https://private-anon-d30cc9ec94-zonky.apiary-mock.com/");

            Token = new Token("c5f6b996-47aa-4c59-8fc7-8a03fcf5da9d", "bearer", "d33c18a7-cc94-4e35-9ac3-c67528a602f4", 299, "SCOPE_APP_WEB");
        }
    }
}