using BlazorBank.Infrastructure.Models.External;
using System.Threading.Tasks;

namespace BlazorBank.Infrastructure.Proxies
{
    public interface IAccountProxy
    {
        Task<GetAccountsResponse> GetAccounts(string customerId, string AccessToken);
    }
}
