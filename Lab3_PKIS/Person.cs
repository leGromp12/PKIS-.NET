using System;
using System.Collections.Generic;

namespace Lab3_PKIS
{
    public class Person : IDateAndCopy, IComparable, IComparer<Person>
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
            name = "Oleksandr";
            surname = "Kochala";
            birthday = new DateTime(2000, 1, 1);
        }

        public DateTime Date
        {
            get { return birthday; }
            set { birthday = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Surname
        {
            get { return surname; }
            set { surname = value; }
        }

        public DateTime Birthday
        {
            get { return birthday; }
            set { birthday = value; }
        }

        public int BirthYear
        {
            get { return birthday.Year; }
            set { birthday = new DateTime(value, birthday.Month, birthday.Day); }
        }

        public override string ToString()
        {
            return string.Format("Name: {0}, Surname: {1}, Birthday: {2}", name, surname, birthday.ToShortDateString());
        }

        public virtual string ToShortString()
        {
            return string.Format("Surname: {0}, Name: {1}", surname, name);
        }

        public override bool Equals(object obj)
        {
            Person other = obj as Person;

            if (other == null)
            {
                return false;
            }

            return name == other.name && surname == other.surname && birthday == other.birthday;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;
                hash = hash * 23 + (name == null ? 0 : name.GetHashCode());
                hash = hash * 23 + (surname == null ? 0 : surname.GetHashCode());
                hash = hash * 23 + birthday.GetHashCode();
                return hash;
            }
        }

        public static bool operator ==(Person p1, Person p2)
        {
            if (ReferenceEquals(p1, p2))
            {
                return true;
            }

            if (ReferenceEquals(p1, null) || ReferenceEquals(p2, null))
            {
                return false;
            }

            return p1.Equals(p2);
        }

        public static bool operator !=(Person p1, Person p2)
        {
            return !(p1 == p2);
        }

        public int CompareTo(object obj)
        {
            if (obj == null)
            {
                return 1;
            }

            Person other = obj as Person;

            if (other == null)
            {
                throw new ArgumentException("Object is not a Person");
            }

            return string.Compare(surname, other.surname, StringComparison.Ordinal);
        }

        public int Compare(Person x, Person y)
        {
            if (ReferenceEquals(x, y))
            {
                return 0;
            }

            if (ReferenceEquals(x, null))
            {
                return -1;
            }

            if (ReferenceEquals(y, null))
            {
                return 1;
            }

            return DateTime.Compare(x.birthday, y.birthday);
        }

        public virtual object DeepCopy()
        {
            return new Person(name, surname, birthday);
        }
    }
}
