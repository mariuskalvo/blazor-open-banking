using BlazorBank.BlazorApp.Models;
using BlazorBank.Services.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorBank.BlazorApp.ViewControllers
{
    public class AccountsViewController
    {
        private readonly IAccountService _accountService;
        public AccountsViewController(IAccountService accountService)
        {
            _accountService = accountService;
        }
        
        public async Task<IEnumerable<AccountWeb>> GetAccounts()
        {
            var accounts = await _accountService.GetAccounts();
            var accountsWeb = accounts.Select(a => new AccountWeb
            {
                AccountName = a.Name,
                AccountNumber = a.AccountNumber,
                Balance = a.Balance,
                Available = a.Available
            });

            return accountsWeb;
        }
    }
}
