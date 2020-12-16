using lab_work_fifth.TransactionCommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_work_fifth
{
    public abstract class Account
    {
        protected string number;
        protected decimal balance;
        protected decimal sumPercentRest;
        protected double percentRest;
        private List<BaseCommand> transactions = new List<BaseCommand>();

        public Account(string number, Bank bank, decimal balance = 0)
        {
            this.number = number;
            this.balance = balance;
            Bank = bank;
        }

        public Bank Bank { get; }

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
            set
            {
                balance = value;
            }
        }

        public List<BaseCommand> Transactions => transactions;

        public bool IsConfirmed { get; set; }

        public virtual void Withdraw(decimal money)
        {
            if (!IsConfirmed && money > Bank.SumLimit)
                throw new ArgumentException("Вас счет является сомнительным. Нельзя снять сумму больше чем " + Bank.SumLimit);

            BaseCommand command = new WithDrawCommand(this, money);
            command.Execute();

            transactions.Add(command);
        }

        public void Put(decimal money)
        {
            BaseCommand command = new PutCommand(this, money);
            command.Execute();

            transactions.Add(command);
        }

        public void Transfer(Account account, decimal money)
        {
            BaseCommand command = new TransferCommand(this, account, money);
            command.Execute();

            transactions.Add(command);
            account.transactions.Add(command);
        }

        public void CalculatePercentRest()
        {
            sumPercentRest += balance * (decimal)percentRest / 100;
        }

        public void AddPercentRest()
        {
            balance += sumPercentRest;
            sumPercentRest = 0;
        }

        public void CancelTransaction(int number)
        {
            transactions[number].Undo();
            transactions.RemoveAt(number);
        }
    }
}
