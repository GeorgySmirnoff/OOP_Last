using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_work_fifth
{
    public class Client
    {
        private string passport;
        private string address;

        public string Name { get; }
        public string Surname { get; }
        public string Passport
        {
            get
            {
                return passport;
            }
            set
            {
                passport = value;
                UpdateAccounts();
            }
        }
        public string Address
        {
            get
            {
                return address;
            }
            set
            {
                address = value;
                UpdateAccounts();
            }
        }

        private List<Account> accounts { get; set; } = new List<Account>();

        public Client(string name, string surname)
        {
            Name = name;
            Surname = surname;
        }

        private void UpdateAccounts()
        {
            bool check = !string.IsNullOrEmpty(Name) && !string.IsNullOrEmpty(Surname) &&
                !string.IsNullOrEmpty(Passport) && !string.IsNullOrEmpty(Address);

            accounts.ForEach(t => t.IsConfirmed = check);
        }

        public void AddAccount(Account account)
        {
            accounts.Add(account);
            UpdateAccounts();
        }
    }
}