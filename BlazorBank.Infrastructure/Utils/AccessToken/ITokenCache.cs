using BlazorBank.Infrastructure.Models.AccessToken;
using System;
using System.Threading.Tasks;

namespace BlazorBank.Infrastructure.Utils
{
    public interface ITokenCache
    {
        Task<string> GetToken(Func<string, Task<GetAccessTokenResponse>> renewTokenFunc, string customerId);
    }
}
