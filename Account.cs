using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountXUnitTest
{
    internal class Account
    {
        private double _balance;
        public void Deposit(double amount)
        {
            if (amount < 0)
                throw new ArgumentException("Deposit amount must be positive");
            _balance += amount;
        }
        public void Withdraw(double amount)
        {
            if (amount < 0)
                throw new ArgumentException("Withdrawal amount must be positive");
            if (amount > _balance)
                throw new InvalidOperationException("Insufficient Funds");
            _balance -= amount;
        }
        public double GetBalance()
        {
            return _balance;
        }
        public void Transfer(Account toAccount, double amount)
        {
            if(toAccount == null) 
                throw new ArgumentNullException(nameof(toAccount));
            Withdraw(amount);
            toAccount.Deposit(amount);
        }

    }
}
