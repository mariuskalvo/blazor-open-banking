using BlazorBank.Services.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorBank.Services.Services
{
    public interface IAccountService
    {
        Task<IEnumerable<AccountInternal>> GetAccounts();
    }
}
