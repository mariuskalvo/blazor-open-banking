namespace BlazorBank.Infrastructure.Configuration
{
    public interface IApiClientConfiguration
    {
        string ClientId { get; }
        string ClientSecret { get; }
    }
}
