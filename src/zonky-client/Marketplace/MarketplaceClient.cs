﻿using System.Collections.Generic;
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

        public async Task<IEnumerable<Loan>> GetLoans(Paging paging = null, SortBy sortBy = null)
        {
            // TODO: allow to filter loans
            var headers = new Dictionary<string, string>();
            if (sortBy != null)
            {
                headers.Add("X-Order", sortBy.ToHeader());
            }
            if (paging != null)
            {
                headers.Add("X-Page", paging.Page.ToString());
                headers.Add("X-Size", paging.Size.ToString());
            }

            return await Client.GetAsync<Loan[]>("loans/marketplace", otherHeaders: headers);
        }

        public async Task<LoanDetail> GetLoanDetail(Token token, int loanId)
        {
            return await Client.GetAsync<LoanDetail>($"loans/{loanId}", token);
        }
    }
}
