using System;

namespace lab_work_first
{
    class Program
    {
        static void Main(string[] args)
        {
            Parcer parc1 = new Parcer("example.ini");
            //Console.WriteLine(parc1.FindValue("NCMD", "SampleRate", typeof(double)));
           //Console.WriteLine(parc1.FindValue("NCMZ", "SampleRate", typeof(double)));
            Console.WriteLine(parc1.FindValue("NCMD", "SampleRate", typeof(double)));
            Console.ReadLine();


            /*var ini = new IniParser();
            var data = ini.Parse(...);

            data.TryGetInt("Common", "LegacyValue");
            data.TryGetDouble("Common", "LegacyValue");
            data.TryGet<double>("Common", "LegacyValue");*/
        }
    }
}
