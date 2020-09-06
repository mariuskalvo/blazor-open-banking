using BlazorBank.Infrastructure.Models.AccessToken;
using LazyCache;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace BlazorBank.Infrastructure.Utils
{
    public class TokenCache : ITokenCache
    {
        private readonly IAppCache _appCache;
        private const string _tokenCacheKey = "access_token";
        private const int _cacheRenewThresholdSeconds = 5 * 60;

        public TokenCache(IAppCache appCache)
        {
            _appCache = appCache;
        }

        public async Task<string> GetToken(Func<string, Task<GetAccessTokenResponse>> renewTokenFunc, string customerId)
        {
            var cachedToken = await _appCache.GetOrAddAsync(_tokenCacheKey, async cacheEntry =>
            {
                var updatedToken = await renewTokenFunc(customerId);
                cacheEntry.AbsoluteExpiration = DateTime.UtcNow.AddSeconds(updatedToken.ExpiresIn - _cacheRenewThresholdSeconds);
                return updatedToken.AccessToken;
            });

            return cachedToken;
        }
    }
}
