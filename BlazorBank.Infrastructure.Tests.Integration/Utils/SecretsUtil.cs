using Microsoft.Extensions.Configuration;
using System;

namespace BlazorBank.Infrastructure.Tests.Integration.Utils
{
    public class SecretsUtil
    {
        private readonly IConfiguration _configuration;
        public SecretsUtil()
        {
            _configuration = new ConfigurationBuilder()
                .AddUserSecrets<SecretsUtil>()
                .Build();
        }

        public string GetUserSecret(string key)
        {
            var customerId = _configuration[key];
            if (customerId == null)
                throw new ArgumentException($"{key} is not set in User Secrets.");

            return customerId;
        }
    }
}
