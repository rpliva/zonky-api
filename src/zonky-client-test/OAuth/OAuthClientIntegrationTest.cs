using Xunit;

namespace Rpliva.Zonky.Client.OAuth
{
    public class OAuthClientIntegrationTest : IntegrationTestBase
    {
        private readonly OAuthClient Target;

        public OAuthClientIntegrationTest()
        {
            Target = new OAuthClient(ApiClient);
        }

        [Fact]
        public void Login()
        {
            var actual = Target.GetAccessToken("test", "test").Result;

            Assert.NotNull(actual);
            Assert.Equal("c5f6b996-47aa-4c59-8fc7-8a03fcf5da9d", actual.AccessToken);
            Assert.Equal("d33c18a7-cc94-4e35-9ac3-c67528a602f4", actual.RefreshToken);
            Assert.Equal("bearer", actual.TokenType);
            Assert.Equal(299, actual.ExpiresIn);
        }
    }
}
