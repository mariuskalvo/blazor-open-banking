using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace BlazorBank.Infrastructure.Models.AccessToken
{
    public class GetAccessTokenResponse
    {
        [JsonProperty("access_token")]
        public string AccessToken { get; set; }

        [JsonProperty("expires_in")]
        public int ExpiresIn { get; set; }

        [JsonProperty("token_type")]
        public string TokenType { get; set; }
    }
}