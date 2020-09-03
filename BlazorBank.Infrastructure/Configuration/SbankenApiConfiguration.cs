namespace BlazorBank.Infrastructure.Configuration
{
    public class SbankenApiConfiguration : IApiClientConfiguration
    {
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
    }
}
