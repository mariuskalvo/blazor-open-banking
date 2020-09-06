using System.Collections.Generic;

namespace BlazorBank.Services.Models
{
    public class AccountOverview
    {
        public IEnumerable<AccountInternal> Accounts { get; set; }
        public IEnumerable<CardInternal> Cards { get; set; }
    }
}
