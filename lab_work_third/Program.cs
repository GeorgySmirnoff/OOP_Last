//using lab_work_third.RaceModel;
using System;
using System.Collections.Generic;

namespace lab_work_third
{
    class Program
    {
        static void Main(string[] args)
        {
            Race<GroundTransport> race = new Race<GroundTransport>(300);
            Boots boots = new Boots();
            DoubleGorbVerblud dgverblud = new DoubleGorbVerblud();
            Kentavr kentavr = new Kentavr();


            Metla metla = new Metla();
            Stupa stupa = new Stupa();


            race.Register(boots);
            race.Register(dgverblud);
            race.Register(kentavr);
            //race.Register(metla);

            Transport winner = race.Start();

            Console.WriteLine(winner.Name);

            Race<AirTransport> race2 = new Race<AirTransport>(300);
            race2.Register(metla);
            //race2.Register(kentavr);
            race2.Register(stupa);

            Race<Transport> race3 = new Race<Transport>(490);
            race3.Register(metla);
            race3.Register(kentavr);

            Transport winner3 = race3.Start();

            Console.WriteLine(winner3.Name);
        }

    }
}

