using BlazorBank.Infrastructure.Proxies;
using BlazorBank.Services.Mappers;
using BlazorBank.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorBank.Services.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountMapper _accountMapper;
        private readonly IAccountProxy _accountProxy;
        private readonly IAccessTokenProxy _accessTokenProxy;
        private readonly CustomerConfiguration _customerConfiguration;

        public AccountService(
            IAccountMapper accountMapper,
            IAccountProxy accountProxy,
            IAccessTokenProxy accessTokenProxy,
            CustomerConfiguration customerConfiguration
        )
        {
            _accountMapper = accountMapper;
            _accountProxy = accountProxy;
            _accessTokenProxy = accessTokenProxy;
            _customerConfiguration = customerConfiguration;
        }
        public async Task<IEnumerable<AccountInternal>> GetAccounts()
        {
            var customerId = _customerConfiguration?.CustomerId;
            if (string.IsNullOrEmpty(customerId))
                throw new ArgumentException("CustomerId is not set.");

            var accessTokenResult = await _accessTokenProxy.GetAccessToken(customerId);
            var getAccountsResult = await _accountProxy.GetAccounts(customerId, accessTokenResult.AccessToken);
            
            if (getAccountsResult.IsError)
                return new List<AccountInternal>();

            return getAccountsResult.Items.Select(_accountMapper.MapAccountExternalToAccountInternal);
        }
    }
}
