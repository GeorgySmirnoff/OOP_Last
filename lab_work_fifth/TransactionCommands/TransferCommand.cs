using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_work_fifth.TransactionCommands
{
    public class TransferCommand : BaseCommand
    {
        private Account accountTo;

        public TransferCommand(Account accountFrom, Account accountTo, decimal sum) : base(accountFrom, sum)
        {
            this.accountTo = accountTo;
        }

        public override void Execute()
        {
            account.Withdraw(Sum);
            accountTo.Put(Sum);
        }

        public override void Undo()
        {
            accountTo.Withdraw(Sum);
            account.Put(Sum);
        }
    }
}