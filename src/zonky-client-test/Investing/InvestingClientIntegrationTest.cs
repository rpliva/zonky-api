using System;
using Xunit;

namespace Rpliva.Zonky.Client.Investing
{
    public class InvestingClientIntegrationTest : IntegrationTestBase
    {
        private readonly InvestingClient Target;

        public InvestingClientIntegrationTest()
        {
            Target = new InvestingClient(ApiClient);
        }

        [Fact]
        public void InvestToLoan()
        {
            Target.Investment(Token, 200, 1, "...").Wait();
        }

        [Fact]
        public void InvestToUnknownLoan()
        {
            Assert.Throws<AggregateException>(() =>
            {
                HttpClient.DefaultRequestHeaders.TryAddWithoutValidation("Prefer", "status=400");

                Target.Investment(Token, 200, 1, "...").Wait();
            });
        }
    }
}
