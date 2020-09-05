using BlazorBank.Infrastructure.Models.Cards;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace BlazorBank.Infrastructure.Proxies
{
    public class CardProxy : ICardProxy
    {
        private readonly HttpClient _httpClient;
        private const string endpointUri = "https://api.sbanken.no/exec.bank/api/v1/cards/";

        public CardProxy(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<GetCardsResponse> GetCards(string customerId, string AccessToken)
        {
            var request = new HttpRequestMessage
            {
                RequestUri = new Uri(endpointUri),
                Method = HttpMethod.Get,
            };

            request.Headers.Add("Authorization", $"Bearer {AccessToken}");
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("customerId", customerId);

            var response = await _httpClient.SendAsync(request);
            var responseString = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<GetCardsResponse>(responseString);
        }
    }
}
