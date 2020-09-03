using BlazorBank.Infrastructure.Configuration;
using BlazorBank.Infrastructure.Models.AccessToken;
using BlazorBank.Infrastructure.Utils;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace BlazorBank.Infrastructure.Proxies
{
    public class AccessTokenProxy : IAccessTokenProxy
    {
        private readonly HttpClient _httpClient;
        private IApiClientConfiguration _apiClientConfiguration;
        private IHeaderEncoder _headerEncoder;
        private const string endpointUri = "https://auth.sbanken.no/identityserver/connect/token";

        public AccessTokenProxy(
            HttpClient httpClient,
            IApiClientConfiguration apiClientConfiguration,
            IHeaderEncoder headerEncoder
        )
        {
            _httpClient = httpClient;
            _headerEncoder = headerEncoder;
            _apiClientConfiguration = apiClientConfiguration;
        }

        public async Task<GetAccessTokenResponse> GetAccessToken(string customerId)
        {
            var authHeader = _headerEncoder.CreateAuthenticationHeaderValue
            (
                _apiClientConfiguration.ClientId,
                _apiClientConfiguration.ClientSecret
            );

            var request = new HttpRequestMessage
            {
                RequestUri = new Uri(endpointUri),
                Method = HttpMethod.Post,
                Content = new StringContent(
                    "grant_type=client_credentials",
                    System.Text.Encoding.UTF8,
                    "application/x-www-form-urlencoded"
                )
            };

            request.Headers.Add("Authorization", $"Basic {authHeader}");
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("customerId", customerId); 

            var response = await _httpClient.SendAsync(request);
            var responseString = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<GetAccessTokenResponse>(responseString);
        }
    }
}
