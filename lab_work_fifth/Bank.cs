using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_work_fifth
{
    public class Bank
    {
        public string Name { get; set; }
        public decimal SumLimit { get; set; }
        private List<Account> accounts = new List<Account>();
        private List<Client> clients = new List<Client>();
        public ICalcPercentRest CreditPercentRest { get; }
        public ICalcPercentRest DepositPercentRest { get; }
        public ICalcPercentRest DebitPercentRest { get; }

        public decimal Commissia { get; set; }

        public Bank(string name, ICalcPercentRest creditPercentRest, ICalcPercentRest depositPercentRest, ICalcPercentRest debitPercentRest)
        {
            Name = name;

            CreditPercentRest = creditPercentRest;
            DepositPercentRest = depositPercentRest;
            DebitPercentRest = debitPercentRest;
        }

        public void AddAccount(Account account)
        {
            accounts.Add(account);
        }

        public Account FindAccount(string number)
        {
            return accounts.FirstOrDefault(t => t.Number == number);
        }

        public void PutMoney(string accountNumber, decimal money)
        {
            Account account = FindAccount(accountNumber);
            if (account == null)
                throw new ArgumentException("Нет счета с таким номером");
            account.Put(money);
        }

        public void TakeMoney(string accountNumber, decimal money)
        {
            Account account = FindAccount(accountNumber);
            if (account == null)
                throw new ArgumentException("Нет счета с таким номером");
            account.Withdraw(money);
        }
    }
}
