namespace BlazorBank.Infrastructure.Utils
{
    public interface IHeaderEncoder
    {
        string CreateAuthenticationHeaderValue(string clientId, string clientSecret); 
    }
}
