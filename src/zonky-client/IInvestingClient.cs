using System.Threading.Tasks;
using Rpliva.Zonky.Client.OAuth;

namespace Rpliva.Zonky.Client.Investing
{
    public interface IInvestingClient
    {
        Task Investment(Token token, int amount, int loanId, string captchaResponse = null);
        void InvestmentIncrease(Token token, int amount);
    }
}