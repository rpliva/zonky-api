using System.Threading.Tasks;
using Rpliva.Zonky.Client.OAuth;

namespace Rpliva.Zonky.Client
{
    public interface IOAuthClient
    {
        Task<Token> GetAccessToken(string username, string password);
    }
}