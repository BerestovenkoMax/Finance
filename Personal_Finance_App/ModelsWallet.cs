namespace PersonalFinanceApp.Models
{
    public class Wallet
    {
        public string Name { get; set; }
        public string Currency { get; set; }
        public decimal Balance { get; private set; }

        public Wallet(string name, string currency)
        {
            Name = name;
            Currency = currency;
            Balance = 0;
        }

        public void AddFunds(decimal amount) => Balance += amount;

        public void WithdrawFunds(decimal amount)
        {
            if (amount > Balance)
                throw new InvalidOperationException("Недостаточно средств.");
            Balance -= amount;
        }
    }
}

