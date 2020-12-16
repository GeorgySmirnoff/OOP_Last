using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_work_fifth
{
    public class Deposit : Account
    {
        private DateTime date;

        public Deposit(string number, Bank bank, DateTime date, decimal balance) : base(number, bank, balance)
        {
            this.date = date;

            percentRest = bank.DepositPercentRest.CalcPercentRest(this);
        }


        public override void Withdraw(decimal money)
        {
            if (TimeManager.Instance.CurrentDate < date)
                throw new Exception("Срок еще не закончился");
            if (money > balance)
                throw new ArgumentException("Недостаточно средств");

            base.Withdraw(money);
        }

    }
}
