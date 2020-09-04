using BlazorBank.Services.Services;

namespace BlazorBank.BlazorApp.Data
{
    public class AccountsDataService
    {
        private readonly IAccountService _accountService;
        public AccountsDataService(IAccountService accountService)
        {
            _accountService = accountService;
        }


    }
}
