using System;
using System.Collections.Generic;
using System.Text;

namespace lab_work_fifth
{
    public abstract class Account
    {
        protected string number;
        protected decimal balance;

        public Account(string number,decimal balance = 0)
        {
            this.number = number;
            this.balance = balance;
        }
        public string Number
        {
            get
            {
                return number;
            }
        }

        public decimal Balance
        {
            get
            {
                return balance;
            }
        }

        public abstract void Withdraw(decimal money);
        public abstract void Put(decimal money);
        public abstract void Transfer(Account accaunt);


    }
}
