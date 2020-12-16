using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_work_fifth
{
    public class CreditAccount : Account
    {
        private decimal limit;

        public CreditAccount(string number, Bank bank, decimal balance = 0, decimal limit = 0) : base(number, bank, balance)
        {
            this.limit = limit;
            percentRest = bank.CreditPercentRest.CalcPercentRest(this);
        }

        public override void Withdraw(decimal money)
        {
            if (balance + limit < money)
                throw new ArgumentException("Недостаточно средств");

            base.Withdraw(money);
        }

        public void ProcessComissia()
        {
            if (balance < 0)
                balance -= Bank.Commissia;
        }
    }
}

