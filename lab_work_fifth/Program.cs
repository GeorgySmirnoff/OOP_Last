using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_work_fifth
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Tuple<decimal, double>> tuples = new List<Tuple<decimal, double>>();
            tuples.Add(Tuple.Create<decimal, double>(50000, 3));
            tuples.Add(Tuple.Create<decimal, double>(100000, 3.5));
            tuples.Add(Tuple.Create<decimal, double>(100000, 4));

            ICalcPercentRest rangeCalc = new RangePersentRest(tuples);
            ICalcPercentRest fixCalc = new FixPercentRest(3);
            ICalcPercentRest nullCalc = new NullPersentRest();

            Bank bank = new Bank("ВТБ", nullCalc, rangeCalc, fixCalc);

            Deposit deposit = new Deposit("123", bank, new DateTime(2020, 12, 20), 10000);
            Client client = new Client("Олег", "Попов");
            client.AddAccount(deposit);
            bank.AddAccount(deposit);

            bank.PutMoney("123", 4000);
            Console.WriteLine($"Счет №{deposit.Number} Баланс = {deposit.Balance}");

            try
            {
                bank.TakeMoney("123", 2000);
                Console.WriteLine($"Счет №{deposit.Number} Баланс = {deposit.Balance}");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }



            Console.ReadLine();
        }
    }
}
