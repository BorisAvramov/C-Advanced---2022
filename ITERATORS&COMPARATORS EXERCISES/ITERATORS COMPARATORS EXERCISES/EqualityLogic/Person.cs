using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace EqualityLogic
{
    public class Person : IComparable<Person>
    {
        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }


        public string Name { get; set; }
        public int Age { get; set; }

        public int CompareTo(Person other)
        {
            var name = this.Name.CompareTo(other.Name);
            var age = this.Age.CompareTo(other.Age);
            if (name != 0)
            {
                return name;
            }

            return age;

        }
        public override bool Equals(object obj)
        {
            Person person = obj as Person;

            return this.Name.Equals(person.Name) && this.Age.Equals(person.Age);    
        }
        public override int GetHashCode()
        {
            return Name.GetHashCode() + Age.GetHashCode();
        }

    }
}
