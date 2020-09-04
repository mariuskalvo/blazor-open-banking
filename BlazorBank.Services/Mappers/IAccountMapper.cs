using BlazorBank.Infrastructure.Models.Accounts;
using BlazorBank.Services.Models;

namespace BlazorBank.Services.Mappers
{
    public interface IAccountMapper
    {
        AccountInternal MapAccountExternalToAccountInternal(AccountExternal accountExternal);
    }
}
