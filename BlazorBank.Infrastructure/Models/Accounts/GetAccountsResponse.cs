using BlazorBank.Infrastructure.Models.Accounts;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace BlazorBank.Infrastructure.Models.External
{
    public class GetAccountsResponse
    {
        public int? AvailableItems { get; set; }
        public IEnumerable<AccountExternal> Items { get; set; }
        public string ErrorType { get; set; }
        public bool IsError { get; set; }
        public int? ErrorCode { get; set; }
        public string ErrorMessage { get; set; }
        public string TraceId { get; set; }
    }
}
