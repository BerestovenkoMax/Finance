namespace PersonalFinanceApp.Models
{
    public class Transaction
    {
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public string Category { get; set; }
        public string Type { get; set; }
        public string WalletName { get; set; }

        public Transaction(decimal amount, DateTime date, string category, string type, string walletName)
        {
            Amount = amount;
            Date = date;
            Category = category;
            Type = type;
            WalletName = walletName;
        }
    }
}

