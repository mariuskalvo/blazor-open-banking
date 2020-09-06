using BlazorBank.Infrastructure.Configuration;
using BlazorBank.Infrastructure.Proxies;
using BlazorBank.Infrastructure.Tests.Integration.Utils;
using BlazorBank.Infrastructure.Utils;
using BlazorBank.Infrastructure.Utils.AccessToken;
using LazyCache;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace BlazorBank.Infrastructure.Tests.Integration
{
    public class AccountProxyTests
    {
        private IAccountProxy _accountProxy;
        private IAccessTokenProxy _accessTokenProxy;
        
        private readonly IHeaderEncoder _headerEncoder;
        private readonly IApiClientConfiguration _apiClientConfiguration;
        private readonly string _customerId;

        public AccountProxyTests()
        {
            var secretsUtil = new SecretsUtil();

            _customerId = secretsUtil.GetUserSecret("CustomerId");
            _headerEncoder = new SbankenHeaderEncoder();
            _apiClientConfiguration = new SbankenApiConfiguration
            {
                ClientId = secretsUtil.GetUserSecret("ClientId"),
                ClientSecret = secretsUtil.GetUserSecret("ClientSecret")
            };
        }

        [SetUp]
        public void Setup()
        {
            var httpClient = new HttpClient();

            _accessTokenProxy = new AccessTokenProxy(
                new HttpClient(),
                _apiClientConfiguration,
                _headerEncoder
            );
            var accessTokenProxy = new AccessTokenProxy(httpClient, _apiClientConfiguration, _headerEncoder);
            var cachedTokenProxy = new CachedTokenProxy(new TokenCache(new CachingService()), accessTokenProxy);

            _accountProxy = new AccountProxy(httpClient, cachedTokenProxy);
        }

        [Test, Explicit]
        public async Task GetAccounts_ReturnsResult()
        {
            var authResponse = await _accessTokenProxy.GetAccessToken(_customerId);
            var response = await _accountProxy.GetAccounts(_customerId);
            Console.Write(JsonConvert.SerializeObject(response, Formatting.Indented));
        }

    
    }
}
