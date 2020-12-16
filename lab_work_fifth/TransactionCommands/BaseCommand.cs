using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_work_fifth.TransactionCommands
{
    public abstract class BaseCommand
    {
        private DateTime date;
        protected decimal sum;
        protected Account account;

        public BaseCommand(Account account, decimal sum)
        {
            this.sum = sum;
            this.account = account;
            date = TimeManager.Instance.CurrentDate;
        }

        public decimal Sum => sum;
        public DateTime Date => date;

        public abstract void Execute();
        public abstract void Undo();
    }
}
