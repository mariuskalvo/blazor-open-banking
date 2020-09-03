using System.Text;
using System.Web;

namespace BlazorBank.Infrastructure.Utils
{
    public class SbankenHeaderEncoder : IHeaderEncoder
    {
        public string CreateAuthenticationHeaderValue(string clientId, string clientSecret)
        {
            var uriEncodedClientId = HttpUtility.UrlEncode(clientId);
            var uriEncodedClientSecret = HttpUtility.UrlEncode(clientSecret);
            var headerString = $"{uriEncodedClientId}:{uriEncodedClientSecret}";
            
            var plainTextBytes = Encoding.UTF8.GetBytes(headerString);
            return System.Convert.ToBase64String(plainTextBytes);
        }
    }
}
