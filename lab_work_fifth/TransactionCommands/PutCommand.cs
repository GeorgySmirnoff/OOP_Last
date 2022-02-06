using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_work_fifth.TransactionCommands
{
    public class PutCommand : BaseCommand
    {
        public PutCommand(Account account, decimal sum) : base(account, sum)
        {
        }

        public override void Execute()
        {
            account.Balance += sum;
        }

        public override void Undo()
        {
            account.Balance -= sum;
        }
    }
}