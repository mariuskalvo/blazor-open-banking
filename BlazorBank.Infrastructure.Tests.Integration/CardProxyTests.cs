using BlazorBank.Infrastructure.Configuration;
using BlazorBank.Infrastructure.Proxies;
using BlazorBank.Infrastructure.Tests.Integration.Utils;
using BlazorBank.Infrastructure.Utils;
using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace BlazorBank.Infrastructure.Tests.Integration
{
    public class CardProxyTests
    {
        private IAccessTokenProxy _accessTokenProxy;
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
            _accessTokenProxy = new AccessTokenProxy(httpClient, _apiClientConfiguration, _headerEncoder);
            _cardProxy = new CardProxy(httpClient);
        }
        
        [Test, Explicit]
        public async Task GetCards_ReturnsResult()
        {
            var accessTokenResponse = await _accessTokenProxy.GetAccessToken(_customerId);
            var cards = await _cardProxy.GetCards(_customerId, accessTokenResponse.AccessToken);
            Console.WriteLine(JsonConvert.SerializeObject(cards, Formatting.Indented));
        }
    }
}
