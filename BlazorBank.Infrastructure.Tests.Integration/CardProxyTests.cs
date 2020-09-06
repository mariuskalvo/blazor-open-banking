using BlazorBank.Infrastructure.Configuration;
using BlazorBank.Infrastructure.Proxies;
using BlazorBank.Infrastructure.Tests.Integration.Utils;
using BlazorBank.Infrastructure.Utils;
using BlazorBank.Infrastructure.Utils.AccessToken;
using LazyCache;
using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace BlazorBank.Infrastructure.Tests.Integration
{
    public class CardProxyTests
    {
        private ICardProxy _cardProxy;

        private readonly IHeaderEncoder _headerEncoder;
        private readonly IApiClientConfiguration _apiClientConfiguration;
        private readonly string _customerId;

        public CardProxyTests()
        {
            var secretsUtil = new SecretsUtil();
            _headerEncoder = new SbankenHeaderEncoder();

            _customerId = secretsUtil.GetUserSecret("CustomerId");
            _apiClientConfiguration = new SbankenApiConfiguration
            {
                ClientId = secretsUtil.GetUserSecret("ClientId"),
                ClientSecret = secretsUtil.GetUserSecret("ClientSecret")
            };
            var httpClient = new HttpClient();

            var accessTokenProxy = new AccessTokenProxy(httpClient, _apiClientConfiguration, _headerEncoder);
            var cachedTokenProxy = new CachedTokenProxy(new TokenCache(new CachingService()), accessTokenProxy);

            _cardProxy = new CardProxy(httpClient, cachedTokenProxy);
        }
        
        [Test, Explicit]
        public async Task GetCards_ReturnsResult()
        {
            var cards = await _cardProxy.GetCards(_customerId);
            Console.WriteLine(JsonConvert.SerializeObject(cards, Formatting.Indented));
        }
    }
}
