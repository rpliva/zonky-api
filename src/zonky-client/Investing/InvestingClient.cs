using System;
using System.Net;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Rpliva.Zonky.Client.OAuth;

namespace Rpliva.Zonky.Client.Investing
{
    public class InvestingClient : IInvestingClient
    { 
        private readonly IApiClient Client;

        public InvestingClient(IApiClient client)
        {
            Client = client;
        }

        public async Task Investment(Token token, int amount, int loanId, string captchaResponse = null)
        {
            var message = new InvestmentParameters { amount = amount, loanId = loanId, captcha_response = captchaResponse ?? "" };
            var response = await Client.JsonPostAsync(JsonConvert.SerializeObject(message), "marketplace/investment", token);

            switch (response.StatusCode)
            {
                case HttpStatusCode.OK:
                    return;
                case HttpStatusCode.BadRequest:
                    throw new InvalidOperationException("Captcha authorization is required.");
                case HttpStatusCode.Forbidden:
                    throw new InvalidOperationException("Captcha verification failed.");
                default:
                    throw new ArgumentOutOfRangeException(response.StatusCode.ToString());
            }
        }

        public void InvestmentIncrease(Token token, int amount)
        {
            // TODO: increase invest
            throw new NotImplementedException();
           /* using (var content = new StringContent("{  \"amount\": 200}", Encoding.UTF8, "application/json"))
            {
                using (HttpResponseMessage response = null)
                {
                    var requestUri = new Uri(baseAddress, "undefined");
                    using (var request = new HttpRequestMessage { Method = new HttpMethod("PATCH"), RequestUri = requestUri, Content = content })
                    {
                        response = await httpClient.SendAsync(request);
                    }
                    string responseData = await response.Content.ReadAsStringAsync();
                }
            } */
        }

        private class InvestmentParameters
        {
            public int amount { get; set; }
            public int loanId { get; set; }
            public string captcha_response { get; set; }
        }
    }
}
