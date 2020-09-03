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
    public class AccessTokenProxyTests
    {
        private IAccessTokenProxy _accessTokenProxy;
        private readonly IHeaderEncoder _headerEncoder;
        private readonly IApiClientConfiguration _apiClientConfiguration;
        private readonly string _customerId;

        public AccessTokenProxyTests()
        {
            var secretsUtil = new SecretsUtil();

            _headerEncoder = new SbankenHeaderEncoder();

            _customerId = secretsUtil.GetUserSecret("CustomerId");
            _apiClientConfiguration = new SbankenApiConfiguration
            {
                ClientId = secretsUtil.GetUserSecret("ClientId"),
                ClientSecret = secretsUtil.GetUserSecret("ClientSecret")
            };

            _accessTokenProxy = new AccessTokenProxy(
                new HttpClient(),
                _apiClientConfiguration,
                _headerEncoder
            );
        }

        [Test, Explicit]
        public async Task GetAccessToken_ReturnsResult()
        {
            var response = await _accessTokenProxy.GetAccessToken(_customerId);
            Console.WriteLine(JsonConvert.SerializeObject(response, Formatting.Indented));
        }

    }
}
