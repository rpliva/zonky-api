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
            throw new NotImplementedException();
        }

        private class InvestmentParameters
        {
            public int amount { get; set; }
            public int loanId { get; set; }
            public string captcha_response { get; set; }
        }
    }
}
