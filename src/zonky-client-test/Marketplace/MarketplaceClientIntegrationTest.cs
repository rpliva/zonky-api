using System;
using System.Linq;
using Xunit;

namespace Rpliva.Zonky.Client.Marketplace
{
    public class MarketplaceClientIntegrationTest : IntegrationTestBase
    {
        private readonly MarketplaceClient Target;

        public MarketplaceClientIntegrationTest()
        {
            Target = new MarketplaceClient(ApiClient);
        }

        [Fact]
        public void GetAllLoans()
        {
            var actual = Target.GetLoans().Result.ToArray();

            Assert.Equal(1, actual.Length);
            Assert.Equal("zonky0", actual.Single().NickName);
        }

        [Fact]
        public void GetDetailOfLoan()
        {
            var actual = Target.GetLoanDetail(Token, 1).Result;

            Assert.NotNull(actual);
            Assert.Equal(1, actual.Id);
        }
    }
}
