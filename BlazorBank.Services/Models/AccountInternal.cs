namespace BlazorBank.Services.Models
{
    public class AccountInternal
    {
        public string AccountId { get; set; }
        public string AccountNumber { get; set; }
        public string OwnerCustomerId { get; set; }
        public string Name { get; set; }
        public string AccountType { get; set; }
        public double Available { get; set; }
        public double Balance { get; set; }
        public double CreditLimit { get; set; }
    }
}
