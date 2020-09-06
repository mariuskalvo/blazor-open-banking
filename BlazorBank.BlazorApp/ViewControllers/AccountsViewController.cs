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
        private readonly ICardService _cardService;

        public AccountsViewController(IAccountService accountService, ICardService cardService)
        {
            _accountService = accountService;
            _cardService = cardService;
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

        public async Task<IEnumerable<CardWeb>> GetCards()
        {
            var cards = await _cardService.GetCards();
            var cardsWeb = cards.Select(c => new CardWeb
            {
                AccountNumber = c.AccountNumber,
                CardType = c.CardType,
                ExpiryDate = c.ExpiryDate
            });

            return cardsWeb;
        }
    }
}
