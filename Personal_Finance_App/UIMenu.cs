using PersonalFinanceApp.Managers;

namespace PersonalFinanceApp.UI
{
    public static class Menu
    {
        public static void ShowMainMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== Personal Finance Manager ===");
                Console.WriteLine("1. Добавить кошелек");
                Console.WriteLine("2. Добавить операцию");
                Console.WriteLine("3. Просмотр транзакций");
                Console.WriteLine("0. Выход");

                var choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        AddWalletMenu();
                        break;
                    case "2":
                        AddTransactionMenu();
                        break;
                    case "3":
                        ViewTransactionsMenu();
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Неверный вариант. Попробуйте еще раз.");
                        break;
                }
            }
        }

        private static void AddWalletMenu()
        {
            Console.Clear();
            Console.Write("Введите имя кошелька: ");
            var name = Console.ReadLine();
            Console.Write("Введите валюту: ");
            var currency = Console.ReadLine();

            FinanceManager.AddWallet(name, currency);
            Console.WriteLine("Кошелек успешно добавлен.");
            Console.ReadKey();
        }

        private static void AddTransactionMenu()
        {
            Console.Clear();
            Console.Write("Введите имя кошелька: ");
            var walletName = Console.ReadLine();
            Console.Write("Введите сумму: ");
            var amount = decimal.Parse(Console.ReadLine());
            Console.Write("Введите категорию: ");
            var category = Console.ReadLine();
            Console.Write("Введите тип (доход/расход): ");
            var type = Console.ReadLine();

            FinanceManager.AddTransaction(amount, category, type, walletName);
            Console.WriteLine("Транзакция добавлена успешно.");
            Console.ReadKey();
        }

        private static void ViewTransactionsMenu()
        {
            Console.Clear();
            Console.Write("Введите дату начала (гггг-мм-дд): ");
            var startDate = DateTime.Parse(Console.ReadLine());
            Console.Write("Введите дату окончания (yyyy-мм-dd): ");
            var endDate = DateTime.Parse(Console.ReadLine());

            FinanceManager.DisplayTransactions(startDate, endDate);
            Console.ReadKey();
        }
    }
}

