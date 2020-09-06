using System;

namespace BlazorBank.Services.Models
{
    public class CardInternal
    {
        public string AccountNumber { get; set; }
        public DateTime ExpiryDate { get; set; }
        public CardStatus Status { get; set; }
        public string CardType { get; set; }
    }
}
