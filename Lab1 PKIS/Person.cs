using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1_PKIS
{
    public class Person
    {
        private string name;
        private string surname;
        private DateTime birthday;

        public Person(string name, string surname, DateTime birthday)
        {
            this.name = name;
            this.surname = surname;
            this.birthday = birthday;
        }

        public Person()
        {
            this.name = "Oleksandr";
            this.surname = "Kochala";
            this.birthday = new DateTime(2000, 1, 1);
        }

        public string Name
        {
            get { return name; }
            init { name = value; }
        }

        public string Surname
        {
            get { return surname; }
            init { surname = value; }
        }

        public DateTime Birthday
        {
            get { return birthday; }
            init { birthday = value; }
        }

        public int BirthYear
        {
            get { return birthday.Year; }
            set
            {
                birthday = new DateTime(
                    value,
                    birthday.Month,
                    birthday.Day
                );
            }
        }
        public override string ToString()
        {
            return $"Name: {name}, Surname: {surname}, Birthday: {birthday.ToShortDateString()}";
        }

        public virtual string ToShortString()
        {
            return $"Surname: {surname}, Name: {name}";
        }
    }
}