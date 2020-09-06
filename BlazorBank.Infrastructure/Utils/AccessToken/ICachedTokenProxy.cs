using System.Threading.Tasks;

namespace BlazorBank.Infrastructure.Utils.AccessToken
{
    public interface ICachedTokenProxy
    {
        Task<string> GetAccessToken(string customerId);
    }
}
