using System;

namespace BlazorBank.Infrastructure.Models.Cards
{
    public class CardExternal
    {
        public string CardId { get; set; }
        public string CardNumber { get; set; }
        public int CardVersionNumber { get; set; }
        public string AccountNumber { get; set; }
        public string CustomerId { get; set; }
        public DateTime ExpiryDate { get; set; }
        public string AccountOwner { get; set; }
        public string Status { get; set; }
        public string CardType { get; set; }
        public string ProductCode { get; set; }
    }
}