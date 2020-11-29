using System;
using System.Collections.Generic;
using System.Text;

namespace lab_work_fifth
{
    class Client
    {
        public string Name { get; }
        public string Surname { get; }
        public string Passport { get; set; }
        public string Address { get; set; }

        public List<Account> Accaunts { get; set; } = new List<Account>();

        public Client(string name,string surname)
        {
            Name = name;
            Surname = surname;
        }

    }
}
