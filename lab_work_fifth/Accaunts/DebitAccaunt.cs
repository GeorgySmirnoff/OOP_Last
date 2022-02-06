using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_work_fifth
{
    public class DebitAccount : Account
    {
        public DebitAccount(string number, Bank bank, decimal balance = 0) : base(number, bank, balance)
        {
            percentRest = bank.DebitPercentRest.CalcPercentRest(this);
        }

        public override void Withdraw(decimal money)
        {
            if (money > balance)
                throw new ArgumentException("Недостаточно средств");

            base.Withdraw(money);
        }
    }
}

