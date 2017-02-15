using System.Collections.Generic;
using System.Threading.Tasks;
using Rpliva.Zonky.Client.Common;
using Rpliva.Zonky.Client.OAuth;

namespace Rpliva.Zonky.Client.Marketplace
{
    public class MarketplaceClient : IMarketplaceClient
    {
        private readonly IApiClient Client;

        public MarketplaceClient(IApiClient client)
        {
            Client = client;
        }

        public async Task<IEnumerable<Loan>> GetLoans()
        {
            // TODO: allow to filter loans
            return await Client.GetAsync<Loan[]>("loans/marketplace");
        }

        public async Task<LoanDetail> GetLoanDetail(Token token, int loanId)
        {
            return await Client.GetAsync<LoanDetail>($"loans/{loanId}", token);
        }
    }
}
