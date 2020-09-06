using BlazorBank.Infrastructure.Models.External;
using BlazorBank.Infrastructure.Utils.AccessToken;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace BlazorBank.Infrastructure.Proxies
{
    public class AccountProxy : IAccountProxy
    {
        private readonly HttpClient _httpClient;
        private readonly ICachedTokenProxy _cachedTokenProxy;
        private const string endpointUri = "https://api.sbanken.no/exec.bank/api/v1/accounts/";

        public AccountProxy(HttpClient httpClient, ICachedTokenProxy cachedTokenProxy)
        {
            _httpClient = httpClient;
            _cachedTokenProxy = cachedTokenProxy;
        }

        public async Task<GetAccountsResponse> GetAccounts(string customerId)
        {

            var request = new HttpRequestMessage
            {
                RequestUri = new Uri(endpointUri),
                Method = HttpMethod.Get,
            };

            var accessToken = await _cachedTokenProxy.GetAccessToken(customerId);

            request.Headers.Add("Authorization", $"Bearer {accessToken}");
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("customerId", customerId);

            var response = await _httpClient.SendAsync(request);
            var responseString = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<GetAccountsResponse>(responseString);
        }
    }
}
