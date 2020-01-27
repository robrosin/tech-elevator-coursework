using System;
using System.Collections.Generic;
using System.Text;

namespace Bank
{
    public class CheckingAccount : Account
    {

        public override void Withdraw(decimal amount)
        {
            if (amount > Balance)
            {
                Console.WriteLine("Lucky you - you have override protection!");
            }
            else
            {
                base.Withdraw(amount);
            }

        }
    }
}
