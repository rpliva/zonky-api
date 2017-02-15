using System.Net.Http;
using Rpliva.Zonky.Client.Common;

namespace Rpliva.Zonky.Client
{
    public class TestApiClient : ApiClient
    {
        public TestApiClient(HttpClient client, string baseUrl)
            : base(client, baseUrl)
        { }

        protected override void CleanupHeaders()
        {
        }
    }
}
