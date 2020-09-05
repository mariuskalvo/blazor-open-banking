using System.Collections.Generic;

namespace BlazorBank.Infrastructure.Models.Cards
{
    public class GetCardsResponse
    {
        public int AvailableItems { get; set; }
        public IEnumerable<CardExternal> Items { get; set; }
        public string ErrorType { get; set; }
        public bool IsError { get; set; }
        public int? ErrorCode { get; set; }
        public string ErrorMessage { get; set; }
        public string TraceId { get; set; }
    }
}