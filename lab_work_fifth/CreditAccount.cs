using System;
using System.Collections.Generic;
using System.Text;

namespace lab_work_fifth
{
    public class CreditAccount : Account
    {
        public CreditAccount(string number, decimal balance = 0) : base(number, balance)
        {
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
            throw new NotImplementedException();
        }
    }
}
