using System;
using System.Collections.Generic;
using System.Text;

namespace Bank
{
    public class SavingsAccount : Account
    {
        public double InterestRate { get; set; }

        public SavingsAccount() { }
        
        public SavingsAccount(decimal balance) : base(balance)
        {
            // Set the initial interest rate
            InterestRate = 0.009;

        }
    }
}
