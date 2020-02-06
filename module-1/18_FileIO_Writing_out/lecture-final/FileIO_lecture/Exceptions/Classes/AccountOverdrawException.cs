using System;
using System.Collections.Generic;
using System.Text;

namespace Exceptions.Classes
{
    public class AccountOverdrawException : Exception
    {
        public string AccountNumber { get; set; }
        public decimal OverdrawAmount { get; set; }

        public AccountOverdrawException(string account, decimal overdrawAmount) : base( $"Account overdraw, account {account} attempted to withdraw {overdrawAmount:C} too much!")
        {
            this.AccountNumber = account;
            this.OverdrawAmount = overdrawAmount;
        }
    }
}
