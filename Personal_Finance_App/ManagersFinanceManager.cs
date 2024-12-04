using PersonalFinanceApp.Models;

namespace PersonalFinanceApp.Managers
{
    public static class FinanceManager
    {
        public static List<Wallet> Wallets = new List<Wallet>();
        public static List<Transaction> Transactions = new List<Transaction>();

        public static void AddWallet(string name, string currency)
        {
            Wallets.Add(new Wallet(name, currency));
        }

        public static void AddTransaction(decimal amount, string category, string type, string walletName)
        {
            var wallet = Wallets.FirstOrDefault(w => w.Name == walletName);
            if (wallet == null)
                throw new InvalidOperationException("Кошелек не найден.");

            if (type == "Расходы") wallet.WithdrawFunds(amount);
            else if (type == "Доход") wallet.AddFunds(amount);

            Transactions.Add(new Transaction(amount, DateTime.Now, category, type, walletName));
        }

        public static void DisplayTransactions(DateTime startDate, DateTime endDate)
        {
            var filteredTransactions = Transactions
                .Where(t => t.Date >= startDate && t.Date <= endDate)
                .OrderBy(t => t.Date);

            foreach (var transaction in filteredTransactions)
            {
                Console.WriteLine($"{transaction.Date}: {transaction.Type} - {transaction.Amount} {transaction.Category} ({transaction.WalletName})");
            }
        }
    }
}

