using BlazorBank.Infrastructure.Models.AccessToken;
using System.Threading.Tasks;

namespace BlazorBank.Infrastructure.Proxies
{
    public interface IAccessTokenProxy
    {
        Task<GetAccessTokenResponse> GetAccessToken(string customerId);
    }
}
