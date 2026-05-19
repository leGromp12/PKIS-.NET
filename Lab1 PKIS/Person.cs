using System;

namespace Lab1_PKIS
{
    public class Person : IDateAndCopy
    {
        protected string name;
        protected string surname;
        protected DateTime birthday;

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

        public DateTime Date
        {
            get { return birthday; }
            init { birthday = value; }
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

        public override bool Equals(object? obj)
        {
            if (obj is Person other)
            {
                return name == other.name &&
                       surname == other.surname &&
                       birthday == other.birthday;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(name, surname, birthday);
        }

        public static bool operator ==(Person p1, Person p2)
        {
            if (ReferenceEquals(p1, p2)) return true;
            if (p1 is null || p2 is null) return false;
            return p1.Equals(p2);
        }

        public static bool operator !=(Person p1, Person p2)
        {
            return !(p1 == p2);
        }

        public virtual object DeepCopy()
        {
            return new Person(name, surname, birthday);
        }

    }
}
