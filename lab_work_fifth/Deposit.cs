using System;
using System.Collections.Generic;
using System.Text;

namespace lab_work_fifth
{
    class Deposit : Account
    {
        private DateTime date;

        public Deposit(string number, DateTime date, decimal balance = 0) : base(number, balance)
        {
            this.date = date;
        }
        public override void Put(decimal money)
        {
            throw new NotImplementedException();
        }

        public override void Transfer(Account accaunt)
        {
            throw new NotImplementedException();
        }

        public override void Withdraw(decimal money)
        {
            if (TimeManager.Instance.CurrentDate < date)
                throw new Exception("");
            if(money > balance)
                throw new ArgumentException("Недостаточно средств");
            balance -= money;
        }
    }
}
