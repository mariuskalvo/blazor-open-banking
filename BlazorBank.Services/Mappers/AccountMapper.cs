using BlazorBank.Infrastructure.Models.Accounts;
using BlazorBank.Services.Models;

namespace BlazorBank.Services.Mappers
{
    public class AccountMapper : IAccountMapper
    {
        public AccountInternal MapAccountExternalToAccountInternal(AccountExternal accountExternal)
        {
            return new AccountInternal
            {
                AccountId = accountExternal.AccountId,
                AccountNumber = accountExternal.AccountNumber,
                AccountType = accountExternal.AccountType,
                Available = accountExternal.Available,
                Balance = accountExternal.Balance,
                CreditLimit = accountExternal.CreditLimit,
                Name = accountExternal.Name,
                OwnerCustomerId = accountExternal.OwnerCustomerId,
            };
        }
    }
}