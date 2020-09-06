using BlazorBank.Infrastructure.Proxies;
using System.Threading.Tasks;

namespace BlazorBank.Infrastructure.Utils.AccessToken
{
    public class CachedTokenProxy : ICachedTokenProxy
    {
        private readonly ITokenCache _tokenCache;
        private readonly IAccessTokenProxy _accessTokenProxy;

        public CachedTokenProxy(ITokenCache tokenCache, IAccessTokenProxy accessTokenProxy)
        {
            _tokenCache = tokenCache;
            _accessTokenProxy = accessTokenProxy;
        }

        public async Task<string> GetAccessToken(string customerId)
        {
            return await _tokenCache.GetToken(_accessTokenProxy.GetAccessToken, customerId);
        }
    }
}
