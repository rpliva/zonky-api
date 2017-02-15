using System.Collections.Generic;
using System.Threading.Tasks;
using Rpliva.Zonky.Client.Common;
using Rpliva.Zonky.Client.Marketplace;
using Rpliva.Zonky.Client.OAuth;

namespace Rpliva.Zonky.Client
{
    public interface IMarketplaceClient
    {
        Task<LoanDetail> GetLoanDetail(Token token, int loanId);
        Task<IEnumerable<Loan>> GetLoans(Paging paging = null, IEnumerable<SortBy> sortBys = null);
    }
}