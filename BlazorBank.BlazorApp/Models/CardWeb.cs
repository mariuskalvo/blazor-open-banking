using System;

namespace BlazorBank.BlazorApp.Models
{
    public class CardWeb
    {
        public string AccountNumber { get; set; }
        public DateTime ExpiryDate { get; set; }
        public string CardType { get; set; }
    }
}
