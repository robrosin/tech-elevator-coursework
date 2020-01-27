using System;

namespace Bank
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            SavingsAccount savings = new SavingsAccount(500m);

            savings.Deposit(100M);

            savings.Withdraw(50M);



            // Mess with checking
            Account checking = new CheckingAccount();

            checking.Deposit(500M);

            checking.Withdraw(1000M);

            checking.Withdraw(100M);

            Console.ReadLine();

        }
    }
}
