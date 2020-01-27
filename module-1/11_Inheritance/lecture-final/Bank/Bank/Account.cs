using System;
using System.Collections.Generic;
using System.Text;

namespace Bank
{
    public class Account
    {
        public decimal Balance { get; protected set; }

        public Account(){ }

        public Account(decimal bal)
        {
            Balance = bal;
        }

        public void Deposit(decimal amount)
        {
            Balance += amount;
            Console.WriteLine($"{amount:C} was deposited, new balance is {Balance:C}.");
        }

        virtual public void Withdraw(decimal amount)
        {
            if (amount <= Balance)
            {
                Balance -= amount;
                Console.WriteLine($"{amount:C} was withdrawn, new balance is {Balance:C}.");
            }
        }


    }
}
